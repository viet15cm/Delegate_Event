using System;

namespace DelegateEvent
{
    //   public delegate void SuKienNhapSo(int x);

    class DuLieuNhap : EventArgs
    {
        public int data { get; set; }

        public DuLieuNhap(int x)
        {
            data = x;
        }
    }
    class UserInput
    {
        public event EventHandler suKienNhapSo;
        public event Action<int> suKienNhapSoAC;

        public int Number { get; set; }
        public void input()
        {
            do
            {
                Console.WriteLine("Nhap vao so nguyen : ");
                string s = Console.ReadLine();
                var i = Int32.Parse(s);
                //Phat di su kien
                //suKienNhapSoAC?.Invoke(i);
                suKienNhapSo?.Invoke(this, new DuLieuNhap(i));
            } while (true);


        }

        
        public void TinhCan (Action<int> action)
        {
            Number +=2;
            suKienNhapSoAC += action;
        }

        public void TinhBinhPhuong(Action<int> action)
        {
            Number += 2;
            suKienNhapSoAC += action;
        }
        

    }

    class TinhCanBac
    {
        public void Sub(UserInput input)
        {
            input.suKienNhapSo += Can;
            
        }
        public void Can(object sender, EventArgs e)
        {
            var i = ((DuLieuNhap)e).data;
            Console.WriteLine($"Can bac hai cua so {i} la : {Math.Sqrt(i)}");
        }

        
    }

    class TinhBinhPhuong
    {
        public void Sub(UserInput input)
        {
            input.suKienNhapSo += BinhPhuong;

        }
        public void BinhPhuong(object sender , EventArgs e)
        {
            var i = ((DuLieuNhap)e).data;
         
            Console.WriteLine($"Binh Phuong cua so {i} la : {i*i}");
        }


    }

    class Program
    {
        static void Main(string[] args)
        {

            UserInput userInput = new UserInput();
            userInput.suKienNhapSo += (object sender , EventArgs e) => {
                var i = ((DuLieuNhap)e).data;

                Console.WriteLine("Ban Vua Nhap So i");
            };
            TinhBinhPhuong tinhBinhPhuong = new TinhBinhPhuong();
            tinhBinhPhuong.Sub(userInput);
            TinhCanBac tinhCanBac = new TinhCanBac();
            tinhCanBac.Sub(userInput);
            /*
            userInput.TinhBinhPhuong((i)=>{

                Console.WriteLine($"Binh Phuong cua so {i} la : {i * i}");
            });

            userInput.TinhCan((i) => {

                Console.WriteLine($"Can bac hai cua so {i} la : {Math.Sqrt(i)}");
            });
            */

            userInput.input();
         
            Console.ReadKey();
        }
    }
}
