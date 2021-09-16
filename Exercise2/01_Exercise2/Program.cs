using System;

namespace _01_Exercise2
{
        public interface I_Animal
        {
            public DateTime Birthdate { set; get; }

            public void Move();
            public void Speak();
            public void NamePet();
            public void Climb();
            public void Color();
            public void Jump();
            public void InputBirthdate();

        }       


        abstract public class BaseAnimal : I_Animal
        {
        public DateTime Birthdate { set; get; }
        public void InputBirthdate()
        {
            Console.WriteLine("\nPlease enter the pet's birth date: ");
            Birthdate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("\nAnimal's birth date: " + Birthdate);
        }
            abstract public void Move();
            abstract public void Speak();

            abstract public void NamePet();
            abstract public void Climb();
            abstract public void Color();
            abstract public void Jump();
        }
        
        abstract public class Pet : BaseAnimal
        {
           public String Name;
           
            
            
            override public void NamePet()
            {
                Console.WriteLine("\nPlease enter the pet's name: ");
                Name = Console.ReadLine();
                Console.WriteLine("\nThe pet's name: " + Name);
            }
        
            override public void Move()
            {
               Console.WriteLine("\nIt moves with 4 legs.");
            }

        }

        public class Monkey : BaseAnimal
        {
            
            override public void Move()
            {
                Console.WriteLine("\nIt moves with 2 legs.");
            }

            override public void Speak()
            {
                Console.WriteLine("\n*Monkey Noises*");
            }

            override public void Climb()
            {
                Console.WriteLine("\nMonkey climbs the tree.");
            }

            public override void Color()
            {
                throw new NotImplementedException();
            }

            public override void Jump()
            {
                throw new NotImplementedException();
            }

            public override void NamePet()
            {
                throw new NotImplementedException();
            }
        }
        public class Dog : Pet
        {
            public String ColorName;
           

            override public void Speak()
            {
                Console.WriteLine("\n*Bark Bark*");
            }

            override public void Color()
            {
                Console.WriteLine("\nPlease enter the pet's color: ");
                ColorName = Console.ReadLine();
                Console.WriteLine("\nThe pet's color: " + ColorName);
        }

            public override void Climb()
            {
                throw new NotImplementedException();
            }

            public override void Jump()
            {
                throw new NotImplementedException();
            }
        }

        public class Cat : Pet
        {
            

            override public void Speak()
            {
                Console.WriteLine("\n*Meow Meow*");
            }

            override public void Jump()
            {
                Console.WriteLine("\nThe cat jumps!");
            }

            public override void Climb()
            {
                throw new NotImplementedException();
            }

            public override void Color()
            {
                throw new NotImplementedException();
            }
        }

        public class Using
        {
            I_Animal[] a;
            int n;

            void InputList()
            {   
                Console.WriteLine("\nInput number of animals: ");
                n = Convert.ToInt32(Console.ReadLine());
                a = new I_Animal[n];
                for (int i=0; i<a.Length; i++)
                {
                    Console.WriteLine("\nInput type of animal (0.Monkey  1.Dog  2.Cat): ");
                    int type = Convert.ToInt32(Console.ReadLine()); //0.Monkey  1.Dog  2.Cat
                    
                    switch(type)
                    {
                        case 0:
                            a[i] = new Monkey();
                            a[i].InputBirthdate();
                            a[i].Move();
                            a[i].Speak();
                            a[i].Climb();
                            break;
                        case 1:
                            
                            a[i] = new Dog();
                            a[i].NamePet();
                            a[i].InputBirthdate();
                            a[i].Move();
                            a[i].Speak();
                            a[i].Color();
                            break;
                        case 2:
                            a[i] = new Cat();
                            a[i].NamePet();
                            a[i].InputBirthdate();
                            a[i].Move();
                            a[i].Speak();
                            a[i].Jump();
                            break;
                        default:
                            Console.WriteLine("Unable to find type.");
                            break;
                }
                }
            }

           public static void Main(String[] args)
           {
                Using u1 = new Using();
                u1.InputList();
           }
        }

}
