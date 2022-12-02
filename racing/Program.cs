using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key; //콘솔키선언
            Console.BufferWidth = Console.WindowWidth = 31; // 콘솔창 가로 사이즈
            Console.BufferHeight = Console.WindowHeight = 40; // 콘솔창 세로 사이즈
            //Console.SetWindowSize(31, 40);
            Console.CursorVisible = false; // 커서가 지워짐
            Random random = new Random(); //랜덤선언
            
            



            int score_count = 0;
            //int dool_num = random.Next(2, 10);
            int[] ran_x = new int[25]; //랜덤 장애물 x 좌표값 저장 배열
            int[] ran_y = new int[25]; ////랜덤 장애물 y좌표값 저장 배열
            int ran = 2;//랜덤 장애물 갯수


            int x = 15, y = 35; //좌표
            
            int score = 0; // 스코어
            
            char hp = '♥'; // 스코어 오브젝트
            
            char dool = '■'; // 장애물 오브젝트          
            
            string player = "●"; // 플레이어 오브젝트
            
            int hp_x = random.Next(1, 29); //hp오브젝트 x좌표 랜덤값
            int hp_y = 1;

            for (int i = 0; i < ran; i++) // 장애물 랜덤좌표 배열 저장
            {
                ran_x[i] = random.Next(1, 29);
                ran_y[i] = 1;
            }

            for (int i = 0; i < ran; i++) //  장애물 랜덤 x 좌표 중복 제거
            {
                for (int j = 0; j < ran; j++)
                {
                    if (i != j && ran_x[i] == ran_x[j])
                    {
                        ran_x[i] = random.Next(1, 29);
                        i = 0;
                        j = 0;
                    }

                }
            }

            for (int i = 0; i < ran; i++) // 장애물과 hp 오브젝트 x 좌표 중복 제거
            {
                if (ran_x[i] == hp_x)
                {
                    hp_x = random.Next(1, 29);
                    i = 0;
                }

            }


            int count = 0;
            while (true)
            {
                ++count;
                
                if (count == 7000 - (score * 2))
                {
                    count = 0;

                    Console.Clear();

                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"Score  {score}");
                    Console.ResetColor();//글씨색상 초기화

                    Console.SetCursorPosition(hp_x, hp_y);
                    Console.ForegroundColor = ConsoleColor.DarkRed; // 글씨 색상변경
                    Console.Write(hp);
                    Console.ResetColor();//글씨색상 초기화
                    ++hp_y;

                   // Console.SetCursorPosition(10, 0);
                    //Console.WriteLine($"{ran_x[0]} {ran_x[1]} {ran_x[2]} {ran_x[3]} {ran_x[4]} {hp_x}"); // 장애물 오브젝트 x 좌표 출력


                    //Console.Write(dool);
                    //++dool_y;

                    Console.SetCursorPosition(x, y); //플레이어 좌표 위치
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(player); // 플레이어 오브젝트 출력
                    Console.ResetColor();//글씨색상 초기화

                    for (int i = 0; i < ran; i++)
                    {
                        Console.SetCursorPosition(ran_x[i], ran_y[i]);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(dool);
                        Console.ResetColor();//글씨색상 초기화
                        ++ran_y[i];
                    }




                    for (int i = 0; i < ran; i++)
                    {

                        if (ran_y[i] > 38) // dool오브젝트의 y좌표가 32줄이 넘었을때 좌표 재설정
                        {
                            ran_x[i] = random.Next(1, 29);
                            ran_y[i] = 1;
                            for (int j = 0; j < ran; j++) // 랜덤 장애물 중복 제거
                            {
                                for (int k = 0; k < ran; k++)
                                {
                                    if (j != k && ran_x[j] == ran_x[k])
                                    {
                                        ran_x[i] = random.Next(1, 29);
                                        j = 0;
                                        k = 0;
                                    }

                                }
                            }
                        }
                        if (ran_x[i] - 1 < x && x < ran_x[i] + 1 && y == ran_y[i]) // dool오브젝트와 플레이어 오브젝트의 좌표가 같을때 게임 종료
                        {
                            Console.SetCursorPosition(5, 20);
                            Console.WriteLine(($"Game over Score : {score}"));
                            return;
                        }
                    }

                    if (hp_x - 2 < x && x < hp_x + 2 && y == hp_y) // hp오브젝트와 플레이어 오브젝트의 좌표가 같을때 score가 오르고, hp 오브젝트 좌표를 재설정
                    {
                        score += 100;
                        ++score_count; //hp오브젝트를 먹었을때 스코어카운트 +1
                        hp_y = 1;
                        hp_x = random.Next(1, 29);
                    }


                    if (score_count == 5) //스코어카운트 +5가 됐을때, 장애물 ++
                    {
                        score_count = 0;
                        ++ran;
                    }


                    if (hp_y > 38) // hp 오브젝트의 y좌표가 32줄이 넘었을때 좌표 재설정
                    {
                        hp_y = 1;
                        hp_x = random.Next(1, 29);
                    }


                }
                if (Console.KeyAvailable) // 키 어벨러블 , 키를 누르기전에 false 키를 누르면 true
                {
                    key = Console.ReadKey();
                    switch (key.Key)
                    {
                        // 좌
                        case ConsoleKey.LeftArrow:
                            if (x > 1)
                            {
                                x -= 2;
                                break;
                            }
                            else break;
                        // 우
                        case ConsoleKey.RightArrow:
                            if (x < 29)
                            {
                                x += 2;
                                break;
                            }
                            else break;
                        // 종료
                        case ConsoleKey.Escape:
                            {
                                return;
                            }
                    }
                }
                

            }
        }
    }
}


