/**
 * Created by Kun on 12/29/13.
 */
class Program {
  def Main(args:Array[String]) {
    System.out.println("Hello, world")
    val a1 = Array(1,2,3,4,5)
    val a2 = a1 map (_ * 3)
    val a3 = a1 filter (_ % 2 != 0)
    System.out.println(a3)
  }
}
