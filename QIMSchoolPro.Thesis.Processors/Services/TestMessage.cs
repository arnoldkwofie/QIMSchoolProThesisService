using System;
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
                request.setAuthApiKey("ebeed7985ad7756fa9eeb276c490431964b6d85c5f8d7df73863e6d194d5bf66");

                // message properties
                request.setMessage(message);
                request.setSMSType(SMSType.GSM_DEFAULT);
                request.setSender("UMaT");      // should be registered

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
