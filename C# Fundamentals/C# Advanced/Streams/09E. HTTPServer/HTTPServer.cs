namespace _09E.HTTPServer
{
    using System;
    using System.Net.Sockets;
    using System.IO;

    public class HTTPServer
    {
        public static void Main()
        {
            Console.WriteLine("Enter port:");
            var listener = new TcpListener(int.Parse(Console.ReadLine()));
            listener.Start();

            while (true)
            {
                Console.WriteLine("Waiting for connection");
                TcpClient client = listener.AcceptTcpClient();

                using (var sr = new StreamReader(client.GetStream()))
                {
                    using (var sw = new StreamWriter(client.GetStream()))
                    {
                        try
                        {
                            string request = sr.ReadLine();
                            Console.WriteLine(request);
                            string[] tokens = request.Split(' ');
                            string page = tokens[1];

                            if (page == "/")
                            {
                                page = "index.html";
                            }

                            using (var file = new StreamReader("../../" + page))
                            {
                                sw.WriteLine("HTTP/1.0 200 OK\n");

                                string data = file.ReadLine();

                                while (data != null)
                                {
                                    sw.WriteLine(data);
                                    sw.Flush();
                                    data = file.ReadLine();
                                }

                            }
                        }
                        catch (Exception e)
                        {
                            //var file = new StreamReader("../../error.html");
                            //sw.WriteLine("HTTP/1.0 404 OK\n");
                            //var data = file.ReadLine();
                            //while (data != null)
                            //{
                            //    sw.WriteLine(data);
                            //    sw.Flush();
                            //    data = file.ReadLine();
                            //}
                        }

                    }
                }

                client.Close();
            }
        }
    }
}