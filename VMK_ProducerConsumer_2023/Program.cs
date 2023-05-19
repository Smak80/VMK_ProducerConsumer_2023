using VMK_ProducerConsumer_2023;

var pr = new Producer(Producer.Type.Red);
var pg = new Producer(Producer.Type.Green);
var pb = new Producer(Producer.Type.Blue);
var c  = new Consumer();

c.Start();
pr.Start();
pg.Start();
pb.Start();

Console.ReadLine();