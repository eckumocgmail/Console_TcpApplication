using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

/// <summary>
/// После соединения клиент выполняет вывод бинарных данных в поток.
/// </summary>
public class TcpClient
{

    public void Request(String server, int port, byte[] output)
    {
        var result = new List<byte>();
        try
        {
            System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient(server, port);
            NetworkStream stream = client.GetStream();
            stream.Write(output, 0, output.Length);
           
            byte[] data = new byte[256];
            String responseData = String.Empty;

            
            Int32 bytes = stream.Read(data, 0, data.Length);
            for(int i=0; i<bytes; i++)
                result.Add(data[i]);

            stream.Close();
            client.Close();
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException: {0}", e);
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }

        Console.WriteLine("\n Press Enter to continue...");
        Console.Read();
    }
}
