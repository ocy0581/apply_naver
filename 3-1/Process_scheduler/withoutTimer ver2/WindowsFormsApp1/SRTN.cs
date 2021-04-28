using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/**
 * 
 * 
 * 
 */
namespace WindowsFormsApp1
{
    /*
      작성자 : 노민우
     SRTN (Shortest Remaining Time Next) - Preemptive SPN
      남은 할당시간이 가장 작은 것부터 할당
     Preemptive

   */ class SRTN : Scheduler
    {
   int [] rt;//남아있는실행시간
   int [] end;//실행시간이 모두 끝난 시점
   int complete=0;//완료된 프로세스의 수
   int []
        small;//실행시간이 작은 것들
        bool compare=false;//남은 시간을 비교할 필요의 유무
   int remain=0;//도착해서 끝나지 않은 프로세스의 수



   public void core1(Process[] process, int time)
    {

        for (int i = 0; i < process.Count(); i++) //새로 도착한 프로세스를 검색
            if (process[i].arrivalTime == time)//도착한 프로세스가 있다면 각 프로세스의 남은 시간을 비교하기 위해 compare을 true로 바꾸어준다
            {
                compare = true;
                remain++;
            }





        if (compare)
        {//이전 프로세스가 작업을 끝낸 경우, 새로운 프로세스가 도착한 경우  실행
            small[0] = process.Count();
            for (int i = 0; i < process.Count(); i++)
            {//남은 실행시간이 제일 작은것을 탐색
                if ((process[i].arrivalTime <= time) && (rt[i] < rt[small[0]]) && rt[i] > 0)
                {
                    small[0] = i;
                }
            }
        }
        compare = false;


        if (small[0] < process.Count() && (rt[small[0]] > 0 && process[small[0]].arrivalTime <= time))
        {
            scheduledProcess[0].Add(process[small[0]].processId);//0코어에서 time시간에 작업한 process[smalltime]의 processID를 입력한다.
            rt[small[0]]--;//남은실행시간은 감소하고
            if (rt[small[0]] == 0)//작업이 완료가 되면
            {
                end[small[0]] = time + 1;//마친 시간을 저장
                complete++;//완료된 프로세스의 수를 늘리고
                if (remain > 1)//도착하여 대기중인 프로세스가 있다면
                    compare = true;//compare true로 바꾸어준다.
                remain--;//도착하여 남아있는 프로세스의 수를 하나 줄인다.
            }
        }
        else
        {
            scheduledProcess[0].Add(-1);
        }
    }


    public void core2(Process[] process, int time)
    {

        for (int i = 0; i < process.Count(); i++) //새로 도착한 프로세스를 검색
            if (process[i].arrivalTime == time)//도착한 프로세스가 있다면 각 프로세스의 남은 시간을 비교하기 위해 compare을 true로 바꾸어준다
            {
                compare = true;
                remain++;
            }


        if (compare)
        {                      // 새로 다른 프로세스가 도착한 경우,이전 프로세스가 작업을 끝낸상태에서 남은 프로세스가 두개 이상 존재하는 경우 실행한다.

            small[0] = process.Count();
            small[1] = process.Count();
            for (int i = 0; i < process.Count(); i++)
            {//small[0]와 small[1]에 남은 실행시간이 제일 작은 두개의 값을 넣는다
                if (process[i].arrivalTime <= time && rt[i] > 0)
                {
                    if (rt[i] < rt[small[0]])
                    {
                        small[1] = small[0];
                        small[0] = i;
                    }
                    else if (rt[small[0]] <= rt[i] && rt[i] < rt[small[1]])
                    {
                        if (small[0] != i)
                            small[1] = i;
                    }

                }

            }


            if (time >= 1)
                for (int i = 0; i < 2; i++)
                    if (small[i] < process.Count())
                    for (int j = 0; j < 2; j++)
                        if (j != i)
                            if (scheduledProcess[j][time - 1] == process[small[i]].processId) //1초전에 j코어에서 작업했으면 계속 j코어에서 작업한다.
                            {
                                int tmp = small[i];
                                small[i] = small[j];
                                small[j] = tmp;
                                break;
                            }

        }




        compare = false;

        for (int i = 0; i < 2; i++)
        {
            if (small[i] < process.Count() && (rt[small[i]] > 0 && process[small[i]].arrivalTime <= time))
            {
                scheduledProcess[i].Add(process[small[i]].processId);//i코어에서 time시간에 작업한 process[small[i]의 processID를 입력한다.
                rt[small[i]]--;
                if (rt[small[i]] == 0)
                {
                    end[small[i]] = time + 1;
                    complete++;

                    if (remain > 2)//대기중인 프로세스가 있다면
                        compare = true;//compare를 true로 바꾸어준다.
                    remain--;//하나의 프로세스가 작업이 끝났으므로 remain수 감소
                }
            }
            else
            {
                scheduledProcess[i].Add(-1);
            }

        }

    }

    public void core3(Process[] process, int time)
    {


        for (int i = 0; i < process.Count(); i++) //새로 도착한 프로세스를 검색
            if (process[i].arrivalTime == time)//도착한 프로세스가 있다면 각 프로세스의 남은 시간을 비교하기 위해 compare을 true로 바꾸어준다
            {
                compare = true;
                remain++;
            }


        if (compare)
        {                      //새로 도착하거나, 이전 프로세스가 작업을 끝낸상태에서 남은 프로세스가 두개 이상 존재할 때 실행

            small[0] = process.Count();
            small[1] = process.Count();
            small[2] = process.Count();

            for (int i = 0; i < process.Count(); i++)//small[0],small[1]과 small[2]에 남은 실행시간이 제일 작은 세개의 값을 각각 넣는다.
            {
                if (process[i].arrivalTime <= time && rt[i] > 0)
                {
                    if (rt[i] < rt[small[0]])
                    {
                        small[2] = small[1];
                        small[1] = small[0];
                        small[0] = i;
                    }
                    else if (rt[small[0]] <= rt[i] && rt[i] < rt[small[1]])
                    {
                        if (small[0] != i)
                        {
                            small[2] = small[1];
                            small[1] = i;
                        }
                    }
                    else if (rt[small[1]] <= rt[i] && rt[i] < rt[small[2]])
                        if (small[1] != i)
                            small[2] = i;
                }
            }



            if (time >= 1)
                for (int i = 0; i < 3; i++)
                    if (small[i] < process.Count())
                        for (int j = 0; j < 2; j++)
                        if (j != i)
                            if (scheduledProcess[j][time - 1] == process[small[i]].processId) //1초전에 j코어에서 작업했으면 계속 j코어에서 작업한다.
                            {
                                int tmp = small[i];
                                small[i] = small[j];
                                small[j] = tmp;
                                break;
                            }

        }

        compare = false;

        for (int i = 0; i < 3; i++)
        {
            if (small[i] < process.Count() && (rt[small[i]] > 0 && process[small[i]].arrivalTime <= time))
            {
                scheduledProcess[i].Add(process[small[i]].processId);//i코어에서 time시간에 작업한 process[small[i]의 processID를 입력한다.
                rt[small[i]]--;
                if (rt[small[i]] == 0)
                {
                    end[small[i]] = time + 1;
                    complete++;

                    if (remain > 2)//대기중인 프로세스가 있다면
                        compare = true;//compare를 true로 바꾸어준다.
                    remain--;//하나의 프로세스가 작업이 끝났으므로 remain수 감소
                }
            }
            else
            {
                scheduledProcess[i].Add(-1);
            }

        }
    }


    public void core4(Process[] process, int time)
    {
        for (int i = 0; i < process.Count(); i++) //새로 도착한 프로세스를 검색
            if (process[i].arrivalTime == time)//도착한게 있다면 비어있는상태로 변환
            {
                compare = true;

                remain++;
            }



        if (compare)
        {  //새로 다른 프로세스가 도착한 경우, 이전 프로세스가 작업을 끝낸상태에서 남은 프로세스가 두개 이상 존재하는 경우


            small[0] = process.Count();
            small[1] = process.Count();
            small[2] = process.Count();
            small[3] = process.Count();

            for (int i = 0; i < process.Count(); i++)
            {
                if (process[i].arrivalTime <= time && rt[i] > 0)
                {
                    if (rt[i] < rt[small[0]])
                    {
                        small[3] = small[2];
                        small[2] = small[1];
                        small[1] = small[0];
                        small[0] = i;
                    }
                    else if (rt[small[0]] <= rt[i] && rt[i] < rt[small[1]])
                    {
                        if (small[0] != i)
                        {
                            small[3] = small[2];
                            small[2] = small[1];
                            small[1] = i;
                        }
                    }
                    else if (rt[small[1]] <= rt[i] && rt[i] < rt[small[2]])
                    {
                        if (small[1] != i)
                            small[3] = small[2];
                        small[2] = i;
                    }
                    else if (rt[small[2]] <= rt[i] && rt[i] < rt[small[3]])
                    {
                        if (small[2] != i)
                            small[3] = i;
                    }
                }
            }

            compare = false;

            if (time >= 1)
                for (int i = 0; i < 4; i++)
                    if (small[i] < process.Count())
                        for (int j = 0; j < 4; j++)
                        if (j != i)
                            if (scheduledProcess[j][time - 1] == process[small[i]].processId) //1초전에 j코어에서 작업했으면 계속 j코어에서 작업한다.
                            {
                                int tmp = small[i];
                                small[i] = small[j];
                                small[j] = tmp;
                                break;
                            }

        }


        for (int i = 0; i < 4; i++)
        {
            if (small[i] < process.Count() && (rt[small[i]] > 0 && process[small[i]].arrivalTime <= time))
            {
                scheduledProcess[i].Add(process[small[i]].processId);//i코어에서 time시간에 작업한 process[small[i]의 processID를 입력한다.
                rt[small[i]]--;
                if (rt[small[i]] == 0)
                {
                    end[small[i]] = time + 1;
                    complete++;
                    if (remain > 4)//도착해서 대기중인 프로세스가 있다면
                        compare = true;//compare를  true 바꾸어준다
                    remain--;//하나의 프로세스가 작업이 끝났으므로 remain 수 감소
                }
            }

            else
            {
                scheduledProcess[i].Add(-1);
            }
        }


    }



        
    public override void scheduling(Process[] process, int processorCount, int rrNum)
    {
        rt = new int[process.Count() + 1];
        small = new int[processorCount];
        end = new int[process.Count()];
        rt[process.Count()] = 1200000000;

        for (int i = 0; i < processorCount; i++)
        {
            small[i] = process.Count();
        }

        for (int i = 0; i < process.Count(); i++)
        {
            rt[i] = process[i].burstTime;

        }

        switch (processorCount)//코어의 개수에따라 실행
        {
            case 1:
                for (int time = 0; complete != process.Count(); time++)
                    core1(process, time);
                break;

            case 2:
                for (int time = 0; complete != process.Count(); time++)
                    core2(process, time);
                break;
            case 3:
                for (int time = 0; complete != process.Count(); time++)
                    core3(process, time);
                break;
            case 4:
                for (int time = 0; complete != process.Count(); time++)
                    core4(process, time);
                break;

        }

        for (int i = 0; i < process.Count(); i++)
        {
            process[i].turnaroundTime = end[i] - process[i].arrivalTime;//TT=끝나는 시간- 도착시간
            process[i].waitingTime = process[i].turnaroundTime - process[i].burstTime;//WT=TT-BT
            process[i].normalizedTime = (float)process[i].turnaroundTime / (float)process[i].burstTime;//NTT=TT/BT

        }

        for (int i = 1; i < process.Count(); i++)
        {
            if (endTime < end[i])
            {
                endTime = end[i];
            }
        }
            if (processorCount < 4)
            {       
                for (int i = processorCount; i < 4; i++)
                {
                    for (int j = scheduledProcess[i].Count(); j < scheduledProcess[0].Count(); j++)
                    {
                        scheduledProcess[i].Add(-1);
                    }
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    scheduledProcess[i].Add(-1);
                }
            }
            endTime = scheduledProcess[0].Count();
        }
        




}

   /*
최종상태 scheduledProcess배열에 해당 시간에 현재 프로세스의 id값이 들어가는
ex) 코어수 1개, p1 id = 1 arrivaltime = 0 bursttime= 3 p2 id = 2 arrivaltime = 2 bursttime= 2
fcfs 방식이면 앞에서 부터 넣으니까
1 1 1 2 2
가 배열에 들어가 있으면 됨
이 추상클래스를 상속받는 public class로 구현해서 그 파일만 넘겨주면됨
그리고 인풋된 process안에 waitingTime,turnarountTime,nomailizedTime까지 추가해야함
이 추상 메소드를 실행했을때 값이 모두 나와야함

*/
}
