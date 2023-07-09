package com.galaxy.controllers;

import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.charset.StandardCharsets;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Collections;
import java.util.Date;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.TimeZone;


import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import com.galaxy.DTO.BillReqDTO;
import com.galaxy.DTO.PaymentResDTO;
import com.galaxy.DTO.ProductBillDTO;
import com.galaxy.DTO.TransactionStatusDTO;
import com.galaxy.VNpay.config.*;
import com.galaxy.entities.Invoice;
import com.galaxy.serviceImp.InvoiceSer;
import com.galaxy.serviceImp.OrderFilmSer;
import com.galaxy.serviceImp.QRcodeSer;





@RestController
public class PaymentController {
	
	
	private BillReqDTO billdata;
	@Autowired
	private InvoiceSer invoiceSer;
	@Autowired
	private OrderFilmSer orderFilmSer;
	
	@Autowired
	private QRcodeSer qRcodeSer;
	
	@PostMapping("/api/create_payment")
	public ResponseEntity<?> createPayMent(@RequestBody BillReqDTO myData) throws UnsupportedEncodingException{
        
	billdata = myData;
	System.err.println(	billdata.toString());
		
	List<ProductBillDTO> p =  myData.getProduct();
	
	
	for (ProductBillDTO item : p) {
		System.out.println("item" + item.show());
	}
		String vnp_Version = "2.1.0";
        String vnp_Command = "pay";
        ///client tra ve
        String orderType = "banking";
       long amount = billdata.getTotal() * 100;
       // long amount = 2000000;
       
        
        String vnp_TxnRef = Config.getRandomNumber(8);
//        String vnp_IpAddr = Config.getIpAddress(req);
        String vnp_TmnCode = Config.vnp_TmnCode;
        
        Map<String, String> vnp_Params = new HashMap<>();
        vnp_Params.put("vnp_Version", vnp_Version);
        vnp_Params.put("vnp_Command", vnp_Command);
        vnp_Params.put("vnp_TmnCode", vnp_TmnCode);
        vnp_Params.put("vnp_Amount", String.valueOf(amount));
        vnp_Params.put("vnp_CurrCode", "VND");
        vnp_Params.put("vnp_BankCode", "NCB");
        

        vnp_Params.put("vnp_TxnRef", vnp_TxnRef);
        vnp_Params.put("vnp_OrderInfo", "Thanh toan don hang:" + vnp_TxnRef);
        vnp_Params.put("vnp_OrderType", orderType);
     
            vnp_Params.put("vnp_Locale", "vn");

        vnp_Params.put("vnp_ReturnUrl", Config.vnp_Returnurl);
        vnp_Params.put("vnp_IpAddr", "127.0.0.1");

        Calendar cld = Calendar.getInstance(TimeZone.getTimeZone("Etc/GMT+7"));
        SimpleDateFormat formatter = new SimpleDateFormat("yyyyMMddHHmmss");
        String vnp_CreateDate = formatter.format(cld.getTime());
        vnp_Params.put("vnp_CreateDate", vnp_CreateDate);
        
        cld.add(Calendar.MINUTE, 15);
        String vnp_ExpireDate = formatter.format(cld.getTime());
        vnp_Params.put("vnp_ExpireDate", vnp_ExpireDate);
        
        List fieldNames = new ArrayList(vnp_Params.keySet());
        Collections.sort(fieldNames);
        StringBuilder hashData = new StringBuilder();
        StringBuilder query = new StringBuilder();
        Iterator itr = fieldNames.iterator();
        while (itr.hasNext()) {
            String fieldName = (String) itr.next();
            String fieldValue = (String) vnp_Params.get(fieldName);
            if ((fieldValue != null) && (fieldValue.length() > 0)) {
                //Build hash data
                hashData.append(fieldName);
                hashData.append('=');
                hashData.append(URLEncoder.encode(fieldValue, StandardCharsets.US_ASCII.toString()));
                //Build query
                query.append(URLEncoder.encode(fieldName, StandardCharsets.US_ASCII.toString()));
                query.append('=');
                query.append(URLEncoder.encode(fieldValue, StandardCharsets.US_ASCII.toString()));
                if (itr.hasNext()) {
                    query.append('&');
                    hashData.append('&');
                }
            }
        }
        String queryUrl = query.toString();
        String vnp_SecureHash = Config.hmacSHA512(Config.vnp_HashSecret, hashData.toString());
        queryUrl += "&vnp_SecureHash=" + vnp_SecureHash;
        String paymentUrl = Config.vnp_PayUrl + "?" + queryUrl;

        PaymentResDTO paymentResDTO = new PaymentResDTO();
        
        paymentResDTO.setStatus("OK");
        paymentResDTO.setMessage("success");
        paymentResDTO.setUrl(paymentUrl);
        
        return ResponseEntity.status(HttpStatus.OK).body(paymentResDTO);
//        return ResponseEntity.ok(paymentResDTO);
//        return paymentUrl;
        

	}
	
	@GetMapping("/api/insertData")
	public String insertData(){
		
		System.out.println(billdata.toString());
	 	qRcodeSer.generateQR(billdata.getMail());
		
	//	System.out.println(myData.toString());
		
		
		  SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
	        Date currentDate = new Date();
	        String Today = dateFormat.format(currentDate);
		
//		// tao moi hoa don
	List<Invoice> Invoice = 	invoiceSer.insertInvoice(billdata.getCustomerID(),Today, billdata.getTotal());
int idInvoice = 	Invoice.get(0).getInvoiceID();
	
//		// tao moi  order Phim
		
		for (String seat : billdata.getSeat()) {
			
			orderFilmSer.addOrderFilm(billdata.getShowTimeID(), seat, idInvoice);
		}
		
		// tao moi  order san pham
		
		List<ProductBillDTO> p =  billdata.getProduct();
		
		
		for (ProductBillDTO item : p) {
			orderFilmSer.addOrderProduct(item.getProductID(), idInvoice, item.getQuantity(), item.getDetails());
		}
		qRcodeSer.generateQR(billdata.getMail());
		return "Data processed successfully";
		
	
	}
	
	@GetMapping("/api/test")
	public void testAPI(){
		
		System.out.println("test");
		
		
//		orderFilmSer.test();
		
		  SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
	        Date currentDate = new Date();
	        String formattedDate = dateFormat.format(currentDate);
		
		
		
	
	}
	
	
	
	
	
	

}
