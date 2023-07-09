package com.galaxy.serviceImp;




import java.time.LocalDate;
import java.util.AbstractMap;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.stream.Collectors;


import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.galaxy.DTO.AlgorithmAndDataRes;
import com.galaxy.DTO.ratingDTO;

import com.galaxy.entities.Customer;
import com.galaxy.entities.Film;
import com.galaxy.entities.Rating;

import com.galaxy.repositories.CustomerRepo;
import com.galaxy.repositories.MovieRepo;
import com.galaxy.repositories.RatingRepo;









@Service
public class RatingSerImp {
	
	
	
	//////////////algorithm
	
	///////////////algorithm
	
    @Autowired
    private CustomerRepo cusRepo;

    @Autowired
    private RatingRepo ratingRepo;
    
    @Autowired
    private MovieRepo MovieRe;
    
   

    
    public List<ratingDTO>  getRatingByFilm(int idFilm) {
		return ratingRepo.getReviewByIdFilm(idFilm);
	}
    
    public void insertUserReview(int filmID, int cusID, LocalDate rateDate, int rate, String comment) {
   	this.ratingRepo.insertNewReview(filmID, cusID, rate, rateDate, comment);
    	
    }
    public int updateUserReview(int filmID, int cusID, LocalDate rateDate, int rate, String comment) {
   return	this.ratingRepo.updateReview(cusID, filmID, rate, rateDate, comment);
    }
    
   
    public List<Film> recommendFilmsForCustomer(int customerId) {
        // Lấy danh sách đánh giá của khách hàng
        List<Rating> customerRatings = ratingRepo.findByUserId(customerId);
        
        Customer currentCustomer = cusRepo.findById(customerId).get();
        if (customerRatings.isEmpty()) {// Nếu khách hàng chưa đánh giá bộ phim nào, gợi ý phim dựa trên đánh giá của các khách hàng khác
        	 System.out.println("chua tung danh gia");
        	List<Rating> allRatings = ratingRepo.findAll();

            // Tạo một map lưu trữ điểm đánh giá trung bình cho từng bộ phim
            Map<Film, Double> filmScores = new HashMap<>();
            Map<Film, Integer> filmCounts = new HashMap<>();

            // Tính toán điểm đánh giá trung bình cho mỗi bộ phim dựa trên đánh giá của các khách hàng khác
            for (Rating rating : allRatings) {
                Film film = rating.getFilmID();
                int ratingValue = rating.getRate();

                filmScores.put(film, filmScores.getOrDefault(film, 0.0) + ratingValue);
                filmCounts.put(film, filmCounts.getOrDefault(film, 0) + 1);
            }

            // Đánh giá trung bình cho từng bộ phim
            for (Film film : filmScores.keySet()) {
                double score = filmScores.get(film);
                int count = filmCounts.get(film);
                double averageRating = score / count;
                filmScores.put(film, averageRating);
            }

            // Sắp xếp lại danh sách các bộ phim theo điểm đánh giá trung bình giảm dần
            List<Film> recommendedFilms = filmScores.entrySet().stream()
                    .sorted(Map.Entry.comparingByValue(Comparator.reverseOrder()))
                    .map(Map.Entry::getKey)
                    .collect(Collectors.toList());

            return recommendedFilms;
        }

  else {
	   System.out.println("da danh gia");
			 // Tạo một map lưu trữ điểm đánh giá cho từng bộ phim và số lượng đánh giá của từng khách hàng khác
	        Map<Film, Double> filmScores = new HashMap<>();
	        Map<Customer, Integer> customerCounts = new HashMap<>();

	        // Tính toán điểm đánh giá trung bình cho mỗi bộ phim và số lượng đánh giá của từng khách hàng khác
	        for (Rating rating : customerRatings) {
	            Film film = rating.getFilmID();
	            int ratingValue = rating.getRate();
	            Customer customer = rating.getCustomerID();

	            filmScores.put(film, filmScores.getOrDefault(film, 0.0) + ratingValue);
	            customerCounts.put(customer, customerCounts.getOrDefault(customer, 0) + 1);
	        }

	        // Sắp xếp các bộ phim theo điểm đánh giá trung bình giảm dần
	        List<Film> recommendedFilms = filmScores.entrySet().stream()
	                .sorted(Map.Entry.comparingByValue(Comparator.reverseOrder()))
	                .map(Map.Entry::getKey)
	                .collect(Collectors.toList());

	        // Tính toán cosine similarity giữa khách hàng hiện tại và các khách hàng khác
	      System.err.println("zo 1");
	        for (Customer customer : customerCounts.keySet()) {
	        	 System.err.println("zo 2");
	            if (!customer.equals(currentCustomer)) {
	                double similarity = calculateCosineSimilarity(currentCustomer, customer);
	                // Sử dụng similarity để điều chỉnh điểm đánh giá dự đoán cho các bộ phim
	                System.err.println("zo 3");
	                System.out.println(similarity);
	                adjustFilmScores(filmScores, customer, similarity);
	            }
	        }
	    

	        // Sắp xếp lại danh sách các bộ phim theo điểm đánh giá sau khi điều chỉnh
	        recommendedFilms = filmScores.entrySet().stream()
	                .sorted(Map.Entry.comparingByValue(Comparator.reverseOrder()))
	                .map(Map.Entry::getKey)
	                .collect(Collectors.toList());

	        return recommendedFilms;
		}
        
       
    }
    
    public double calculateCosineSimilarity(Customer customerA, Customer customerB) {
        // Lấy danh sách các bộ phim đã được đánh giá bởi cả hai khách hàng
        List<Rating> commonRatings = ratingRepo.findCommonRatings(customerA.getCustomerID(), customerB.getCustomerID());

        // Tạo vector đánh giá cho cả hai khách hàng
        double[] ratingsA = new double[commonRatings.size()];
        double[] ratingsB = new double[commonRatings.size()];

        for (int i = 0; i < commonRatings.size(); i++) {
            Rating rating = commonRatings.get(i);
            ratingsA[i] = rating.getRate();
            ratingsB[i] = ratingRepo.findRatingByFilmAndCustomer(rating.getFilmID().getFilmID(), customerB.getCustomerID());
        }

        // Tính toán cosine similarity
        double dotProduct = 0;
        double normA = 0;
        double normB = 0;

        for (int i = 0; i < commonRatings.size(); i++) {
            dotProduct += ratingsA[i] * ratingsB[i];
            normA += Math.pow(ratingsA[i], 2);
            normB += Math.pow(ratingsB[i], 2);
        }

        double similarity = dotProduct / (Math.sqrt(normA) * Math.sqrt(normB));
       
        return similarity;
    }

    private void adjustFilmScores(Map<Film, Double> filmScores, Customer customer, double similarity) {
        for (Film film : filmScores.keySet()) {
            double rating = filmScores.get(film);
            double adjustedRating = rating * similarity;
            filmScores.put(film, adjustedRating);
        }
    }
    
   
    /////////////////////////////////////////////////COLLABORATIVE FITERING - lap ma tran//////////////////////////////////////////////////////////////////////

    
    public AlgorithmAndDataRes rec(int IdCus) {
    	
    	AlgorithmAndDataRes dataRes = new AlgorithmAndDataRes();
    	/// lấy ra danh sách tất cả người dùng
    	List<Customer> customers = cusRepo.findAll();
    	System.out.println(customers.size());
    	
    	for (Customer item : customers) {
    		dataRes.getNameCus().add(item.getName());
		}
    	/// lấy ra danh sách các film còn hoạt động
    	List<Film> films = MovieRe.findAll();
    	System.out.println(films.size());
    	
    	for (Film f : films) {
    		dataRes.getNameItem().add(f.getName());
		}

    	int numCustomers = customers.size();
    	int numFilms = films.size();

    	double[][] initialMatrix = new double[numCustomers][numFilms];

    	for (int i = 0; i < numCustomers; i++) {
    	    Customer customer = customers.get(i);
    	   
    	    List<Rating> ratings = customer.getRating();
    	 
    	    for (int j = 0; j < numFilms; j++) {
    	        Film film = films.get(j);
    	     // Hàm tìm giá trị đánh giá từ danh sách đánh giá của khách hàng
    	        double ratingValue = findRatingValue(ratings, film); 
    	        
    	        initialMatrix[i][j] = ratingValue;
    	    }
    	}
    	
    	/// set ma tran khoi tao tra ve 
    		dataRes.setInitMatrix(initialMatrix);

    	// Tính độ tương tự giữa các cặp người dùng
    	double[][] similarityMatrix = new double[numCustomers][numCustomers];

    	for (int i = 0; i < numCustomers; i++) {
    	    for (int j = 0; j < numCustomers; j++) {
    	        List<Rating> ratingsA = customers.get(i).getRating();
    	        List<Rating> ratingsB = customers.get(j).getRating();

    	        double similarity = cal(ratingsA, ratingsB); // Hàm tính độ tương tự (ví dụ: cosine similarity)

    	        similarityMatrix[i][j] = similarity;
    	    }
    	}
    	/// set ma tran consine tra ve 
    	dataRes.setSimilarMatrix(similarityMatrix);
    	
    	printSimilarityMatrix(initialMatrix);
    	
    	printSimilarityMatrix(similarityMatrix);
    	
    	printSimilarityScores(IdCus,similarityMatrix,customers,dataRes);
    	
    	/// set phim goi y de tra ve
    	dataRes.setDataFilm(recommendMovies(IdCus,similarityMatrix) );	
    	
//    return	recommendMovies(IdCus,similarityMatrix);
    	return dataRes;
    	
    	

    }
    
    private double findRatingValue(List<Rating> ratings, Film film) {
        for (Rating rating : ratings) {
            if (rating.getFilmID().equals(film)) {
                return rating.getRate(); // Giả sử ratingValue là thuộc tính trong lớp Rating để lưu giá trị đánh giá
            }
        }
        return 0.0; // Trả về 0.0 nếu không tìm thấy giá trị đánh giá cho bộ phim
    }

    public void printSimilarityMatrix(double[][] similarityMatrix) {
        int numRows = similarityMatrix.length;
        int numCols = similarityMatrix[0].length;

        for (int i = 0; i < numRows; i++) {
            for (int j = 0; j < numCols; j++) {
            	String formattedValue = String.format("%.2f", similarityMatrix[i][j]);
                System.out.print(formattedValue + " ");
            }
            System.out.println(); // Xuống dòng sau khi in xong một hàng
        }
    }
    
    private double cal(List<Rating> ratingsA, List<Rating> ratingsB) {
        int numRatingsA = ratingsA.size();
        int numRatingsB = ratingsB.size();

        int maxLength = Math.max(numRatingsA, numRatingsB);

        double[] ratingsArrayA = new double[maxLength];
        double[] ratingsArrayB = new double[maxLength];

        // Gán giá trị mặc định 0 cho các phần tử thiếu của danh sách ngắn hơn
        for (int i = 0; i < maxLength; i++) {
            if (i < numRatingsA) {
                ratingsArrayA[i] = ratingsA.get(i).getRate();
            } else {
                ratingsArrayA[i] = 0;
            }

            if (i < numRatingsB) {
                ratingsArrayB[i] = ratingsB.get(i).getRate();
            } else {
                ratingsArrayB[i] = 0;
            }
        }

        // Tiến hành tính toán độ tương tự cosine
        double dotProduct = 0;
        double normA = 0;
        double normB = 0;

        for (int i = 0; i < maxLength; i++) {
            dotProduct += ratingsArrayA[i] * ratingsArrayB[i];
            normA += Math.pow(ratingsArrayA[i], 2);
            normB += Math.pow(ratingsArrayB[i], 2);
        }

        double similarity = dotProduct / (Math.sqrt(normA) * Math.sqrt(normB));
        return similarity;
    }
    
    
    public void printSimilarityScores(int targetUserId, double[][] similarityMatrix, List<Customer> userList,AlgorithmAndDataRes dataRes) {
        int targetUserIndex = -1;
        
        // Tìm chỉ số của targetUser trong similarityMatrix
        for (int i = 0; i < userList.size(); i++) {
            Customer user = userList.get(i);
            if (user.getCustomerID() == targetUserId) {
                targetUserIndex = i;
                break;
            }
        }
        
        if (targetUserIndex == -1) {
            // Người dùng không tồn tại trong danh sách
            return;
        }
        
        double[] similarityScores = similarityMatrix[targetUserIndex];
        
        // Duyệt qua mức độ tương tự và in ra điểm tương tự của từng cặp người dùng
        for (int i = 0; i < similarityScores.length; i++) {
            if (i != targetUserIndex) {
                double similarity = similarityScores[i];
                Customer otherUser = userList.get(i);
                dataRes.getCoupleSimilar().add(otherUser.getName()  + ": " + + similarity );
                System.out.println("Similarity score between current user and User " + otherUser.getName() + ": " + similarity);
            }
        }
    }
    
    
    //////////////////////// goi y phim///////////////////////////
    public Set<Film> recommendMovies(int userId, double[][] similarityMatrix) {
    	Set<Film> recommendedMovies = new HashSet<>();
        
        // Tìm người dùng có độ tương đồng cao với người dùng hiện tại
        List<Integer> similarUsers = findSimilarUsers(userId, similarityMatrix);
        
        // Lấy danh sách các bộ phim mà những người dùng có độ tương đồng cao đã đánh giá
        Set<Film> ratedMovies = getRatedMovies(userId);
        
        // Gợi ý các bộ phim hàng đầu từ những người dùng tương tự
        for (int user : similarUsers) {
        	Set<Film> userRatedMovies = getRatedMovies(user);
            userRatedMovies.removeAll(ratedMovies); // Loại bỏ những bộ phim đã được người dùng hiện tại đánh giá
            recommendedMovies.addAll(userRatedMovies);
        }
        
        return recommendedMovies;
    }
    public Set<Film> getRatedMovies(int userId) {
        Customer user = cusRepo.findById(userId).orElse(null);
        if (user == null) {
            return Collections.emptySet(); // Trả về danh sách rỗng nếu không tìm thấy người dùng
        }

        List<Rating> ratings = ratingRepo.findByUserId(user.getCustomerID());
        Set<Film> ratedMovies = new HashSet<>();

        for (Rating rating : ratings) {
            ratedMovies.add(rating.getFilmID());
        }

        return ratedMovies;
    }

    private List<Integer> findSimilarUsers(int userId, double[][] similarityMatrix) {
        List<Integer> similarUsers = new ArrayList<>();
        
        // Tìm người dùng có độ tương đồng cao hơn ngưỡng
        double threshold = 0.5; // Ngưỡng độ tương đồng
        try {
        	for (int i = 0; i < similarityMatrix[userId].length; i++) {
        		if (similarityMatrix[userId][i] > threshold) {
        			similarUsers.add(i);
        		}
        	}
			
		} catch (Exception e) {
			// TODO: handle exception
		}
        
        return similarUsers;
    }
    
    
   

  
}





