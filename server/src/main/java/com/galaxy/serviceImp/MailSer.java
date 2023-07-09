package com.galaxy.serviceImp;

import java.util.Properties;

import org.springframework.stereotype.Service;

import javax.activation.DataHandler;
import javax.activation.DataSource;
import javax.activation.FileDataSource;
import javax.mail.*;
import javax.mail.internet.*;

@Service
public class MailSer {

	public void sendMail(String Address, String QR_Path) {
		 // Cấu hình thông tin mail server và email
        String host = "smtp.gmail.com";
        String port = "587";
        String username = "duansocua242@gmail.com";
        String password = "qgsvfjwnlafhhjry";
        String fromAddress = "duansocua242@gmail.com";
        String toAddress = Address;
        String subject = "Galaxy Cenema";
        String body = "Đây là thông tin về vé xem phim của bạn vui lòng xem kĩ ngày chiếu và suất chiếu. Mọi thắc mắc vui lòng liên hệ hotline!! From Daun service guest with love.";
        String htmlContent = "<div><h1>Đây là thông tin vé của bạn!</h1>"
        		+ "				<p>xin vui lòng để ý thông tin vé</p></div>"
        + "						<p>Mã vé:</p> <strong>GX210</strong> </div>";

        // Đường dẫn tới tệp QR code
        String qrCodeFilePath = QR_Path;

        // Cấu hình các thuộc tính của mail server
        Properties properties = new Properties();
        properties.put("mail.smtp.auth", "true");
        properties.put("mail.smtp.starttls.enable", "true");
        properties.put("mail.smtp.host", host);
        properties.put("mail.smtp.port", port);
        properties.put("mail.smtp.ssl.trust", "smtp.gmail.com");
        properties.put("mail.smtp.ssl.protocols", "TLSv1.2");

        // Tạo đối tượng Session để thực hiện gửi email
        Session session = Session.getInstance(properties, new Authenticator() {
            @Override
            protected PasswordAuthentication getPasswordAuthentication() {
                return new PasswordAuthentication(username, password);
            }
        });

        try {
            // Tạo đối tượng MimeMessage
            MimeMessage message = new MimeMessage(session);
            message.setFrom(new InternetAddress(fromAddress));
            message.addRecipient(Message.RecipientType.TO, new InternetAddress(toAddress));
            message.setSubject(subject);

            // Tạo phần thân email
            MimeBodyPart messageBodyPart = new MimeBodyPart();
            messageBodyPart.setText(body);

            // Tạo phần đính kèm QR code
            MimeBodyPart qrCodeAttachmentPart = new MimeBodyPart();
            DataSource qrCodeDataSource = new FileDataSource(qrCodeFilePath);
            qrCodeAttachmentPart.setDataHandler(new DataHandler(qrCodeDataSource));
            qrCodeAttachmentPart.setFileName("qr_code.png");

            // Kết hợp các phần thành một phần tử đính kèm
            Multipart multipart = new MimeMultipart();
            multipart.addBodyPart(messageBodyPart);
            multipart.addBodyPart(qrCodeAttachmentPart);
            
            message.setContent(htmlContent, "text/html");
            

            // Thiết lập phần tử đính kèm vào email
            message.setContent(multipart);

            // Gửi email
            Transport.send(message);

            System.out.println("Email sent successfully!");
        } catch (MessagingException e) {
            e.printStackTrace();
        }
	}
}
