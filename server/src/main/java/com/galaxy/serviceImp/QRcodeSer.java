package com.galaxy.serviceImp;
import javax.imageio.ImageIO;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.google.zxing.BarcodeFormat;
import com.google.zxing.WriterException;
import com.google.zxing.common.BitMatrix;
import com.google.zxing.qrcode.QRCodeWriter;

import java.awt.Graphics2D;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.IOException;
import java.util.Base64;
import java.util.UUID;

@Service
public class QRcodeSer {
	
	@Autowired
	MailSer mailSer;
	
	  String qrCodeData = "GLX231";
	  String filePath = "C:/Users/duann/source/repos/đồ án tốt nghiệp/QR code/qrcode.png";

      int width = 300;
      int height = 300;
      
      public void generateQR(String mail) {
    	  try {
              BitMatrix bitMatrix = new QRCodeWriter().encode(qrCodeData, BarcodeFormat.QR_CODE, width, height);
              BufferedImage qrCodeImage = new BufferedImage(width, height, BufferedImage.TYPE_INT_RGB);
              qrCodeImage.createGraphics();

              Graphics2D graphics = (Graphics2D) qrCodeImage.getGraphics();
              graphics.setColor(java.awt.Color.WHITE);
              graphics.fillRect(0, 0, width, height);
              graphics.setColor(java.awt.Color.BLACK);

              for (int i = 0; i < width; i++) {
                  for (int j = 0; j < height; j++) {
                      if (bitMatrix.get(i, j)) {
                          graphics.fillRect(i, j, 1, 1);
                      }
                  }
              }

              ImageIO.write(qrCodeImage, "png", new File(filePath));
              System.out.println("QR code generated successfully.");
              
              mailSer.sendMail("duannguyen242@gmail.com", filePath);
          } catch (WriterException | IOException e) {
              e.printStackTrace();
          }
    	  
      }
}


