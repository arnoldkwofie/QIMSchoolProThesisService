﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenoph.Notify.Enums;
using Zenoph.Notify.Request;

namespace QIMSchoolPro.Thesis.Processors.Services
{
    public class TestMessage
    {
        public static void Send(string message, string phone)
        {
            try
            {
                // initialise request object 
                SMSRequest request = new SMSRequest();

                // set request host
                request.setHost("api.smsonlinegh.com");

                // By default requests will be sent using SSL/TLS with https connection.
                // If you encounter SSL/TLS warning or error, your machine may be using unsupported
                // SSL/TLS version. In that case uncomment the following line to set it to false
                // request.useSecureConnection(false);

                // set authentication details.
                request.setAuthModel(AuthModel.API_KEY);
                request.setAuthApiKey("49244f8ffc3ed558188b699747d07186a675db279f9b42408ead155535b78571");

                // message properties
                request.setMessage(message);
                request.setSMSType(SMSType.GSM_DEFAULT);
                request.setSender("TEST");      // should be registered

                // add message destination
                request.addDestination(phone);

                // send message.
                request.submit();
            }

            catch (Exception ex)
            {
                // output error message
                Console.WriteLine(String.Format("Error: {0}.", ex.Message));
            }
        }
    }

}