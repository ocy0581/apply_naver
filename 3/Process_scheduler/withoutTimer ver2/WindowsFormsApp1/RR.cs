

using System;
using System.Drawing;
using System.Linq;
using WindowsFormsApp1;
/**
 * 작성자 : 정형준
 * 내용   : RR알고리즘의 구현
 * 1차 수정 보고 : 112줄 ~ 113줄 모든 프로세스의 arrivalTime이 같은 경우를 대비함
 *               + 126~133줄 for문 추가 // rrTime이 끝나서 dyprocess의 배열 순서가 뒤바뀔때 curretprocess[]안의 내용물도 배열 순서가 뒤바뀌는 것을 고려하여 수정
 *
 * 2차 수정 보고 : 46줄 조건에 chekingArr[0] == 0 조건 삭제
 *
 * 3차 수정 보고 : checkingArr[]이라는 배열 (프로세서가 사용한 프로세스의 id ) 삭제 후 ar[]이라는 배열 대체 사용(dyProcess내에 존재하는 process의 순서가 기준)
 * 4차 수정 보고 : for문 바로 밑에 프로세스의 수보다 큰 프로세서는 continue 시킴
 * 5차 수정 보고 : RRTIME == 0 일 경우 CURRENTPROCESS순서 수정 후 AR[]순서 수정하던 것을 AR먼저 수정하는 것으로 바꿈
 */

class RR : Scheduler
{

    public override void scheduling(Process[] process, int processorCount, int rrNum)
    {
        int maxTime = 100;
        Process[] dyProcess = (Process[])process.Clone();
        Process[] returnProcess = (Process[])process.Clone();
        int[] checkingArr = new int[dyProcess.Count()]; //이번 시간동안 해당 프로세서가 일을 했는지 안했는지 체크

        for (int i = 0; i < dyProcess.Count(); i++)
        {
            dyProcess[i].dyburstTime = dyProcess[i].burstTime;
            dyProcess[i].rrTime = rrNum;
            dyProcess[i].dyArrivalTime = dyProcess[i].arrivalTime;
        }
        Array.Sort(dyProcess);//도착시간을 기준으로 정렬
        int[] currentProcess = new int[4]; // 현제 프로세서가 동작중인 프로세스의 id를 저장하는 배열
        for (int i = 0; i < 4; i++)
            currentProcess[i] = -1;
        int check = 0;//처리해야할 프로세서가 없을 경우 종료를 위한 변수

        for (int time = 0; check == 0; time++)
        {
            endTime = time;
            for(int i = 0; i < checkingArr.Count(); i++)
            {
                checkingArr[i] = 0;
            }
            for(int i = 0; i < 4; i++)
            {
                scheduledProcess[i].Add(-1);
            }

/*
 * [-1 ]
 * [-1 ]
 * [-1 ]
 * [-1 ]
 */
            for (int processor = 0; processor < processorCount; processor++)
            {
                
                if (dyProcess.Count() - 1 < processor)
                    continue;
                int trash = 0;//계산이 끝난 프로세서의 개수
                for (int i = 0; i < dyProcess.Count(); i++)
                    if (dyProcess[i].arrivalTime == 9999)
                        trash++;
                if (trash == dyProcess.Count()) { check = 1; break; }//모든 프로세서 처리 완료 상태

                int[] ar = new int[dyProcess.Count()];//현제 살아있는 프로세서가 있는 칸은 1 / 죽어있는 프로세서는 0
                for (int i = 0; i < processorCount; i++)
                    if (currentProcess[i] != -1)
                        ar[currentProcess[i]] = 1;

                if (currentProcess[processor] == -1)
                {
                    int currentMax = Math.Max(currentProcess[0], Math.Max(currentProcess[1], Math.Max(currentProcess[2], currentProcess[3])));//맨 처음일 경우
                    if (currentMax == -1 && time >= dyProcess[0].dyArrivalTime)
                    {
                        currentProcess[processor] = 0;
                    }
                    else
                    {
                        for (int i = 0; i < dyProcess.Count(); i++)
                        {//일할 프로세스 탐색
                            if (ar[i] == 0 && dyProcess[i].dyArrivalTime <= time && dyProcess[i].arrivalTime < 9999)
                            {
                                currentProcess[processor] = i;
                                break;
                            }
                        }
                    }
                }



                if (currentProcess[processor] == -1) continue;//그럼에도 해당 프로세서가 없다면 할만한 프로세서가 없다는 뜻
                if (dyProcess[currentProcess[processor]].processId == -1) continue;
                if (checkingArr[dyProcess[currentProcess[processor]].processId - 1] > 0) continue;

                if (dyProcess[currentProcess[processor]].dyArrivalTime <= time)
                {//한 프로세스의 일이 끝났다면
                    scheduledProcess[processor][time] = dyProcess[currentProcess[processor]].processId;
                    dyProcess[currentProcess[processor]].dyburstTime--;
                    dyProcess[currentProcess[processor]].rrTime--;
                    checkingArr[dyProcess[currentProcess[processor]].processId - 1]++;

                    if (dyProcess[currentProcess[processor]].dyburstTime <= 0)
                    {//프로세스에 할당된 일의 종료
                        returnProcess[dyProcess[currentProcess[processor]].processId - 1].turnaroundTime = time - returnProcess[dyProcess[currentProcess[processor]].processId - 1].arrivalTime + 1;//turnaroundTime 계산

                        Process trashProcess = new Process(-1, 9999, 9999,Color.Red ); trashProcess.dyArrivalTime = 9999;//쓰레기 process객체 생성
                        for (int i = currentProcess[processor]; i < dyProcess.Count() - 1; i++)
                            dyProcess[i] = dyProcess[i + 1];//시프트
                        
                        dyProcess[dyProcess.Count() - 1] = trashProcess;//쓰레기process 삽입
                        for (int i = 0; i < 4; i++)
                            if (currentProcess[i] > currentProcess[processor] && currentProcess[i] != -1)
                                currentProcess[i]--;

                        for (int i = currentProcess[processor]; i < dyProcess.Count() - 1; i++)
                            ar[i] = ar[i + 1];

                        currentProcess[processor] = -1;
                    }
                    else if (dyProcess[currentProcess[processor]].rrTime <= 0)
                    {//할당된 rrTime의 종료
                        dyProcess[currentProcess[processor]].rrTime = rrNum;
                        int finding = -1;//삽입위치
                        dyProcess[currentProcess[processor]].dyArrivalTime = time;//삽입할때 arrivaltime 지금 시간으로 조정

                        for (int i = 0; i < dyProcess.Count(); i++)
                        {//삽입위치찾기
                            if (dyProcess[i].dyArrivalTime > time + 1)
                            {
                                finding = i;
                                break;
                            }
                        }
                        if (finding == -1)//모두가 같은 arrivaltime을 가지고 있을때 finding을 맨뒤로 이동
                            finding = dyProcess.Count() - trash;
                        Process tmp = dyProcess[currentProcess[processor]];
                        if (finding != 0)
                        {
                            for (int i = currentProcess[processor]; i < finding - 1; i++)//땡기고 삽입
                                dyProcess[i] = dyProcess[i + 1];

                            dyProcess[finding - 1] = tmp;

                        }
                        else if (finding == 0)
                            dyProcess[currentProcess[processor]] = tmp;

                        for (int i = currentProcess[processor]; i < finding - 1; i++)//AR 위치 변환
                            ar[i] = ar[i + 1];
                        ar[finding - 1] = 1;

                        for (int i = 0; i < 4; i++)
                        {//rrTime이 끝나서 dyprocess의 배열 순서가 뒤바뀔때 curretprocess[]안의 내용물도 배열 순서가 뒤바뀌는 것을 고려하여 수정
                            if (currentProcess[i] == -1)
                                continue;
                            else if (currentProcess[i] == 0)
                                currentProcess[i] = finding - 1;

                            currentProcess[i]--;
                        }
                        currentProcess[processor] = -1;
                    }
                }
            }
        }//for문 종료

        for (int i = 0; i < returnProcess.Count(); i++)
        {
            returnProcess[i].waitingTime = returnProcess[i].turnaroundTime - returnProcess[i].burstTime;//waitingTime 계산
            returnProcess[i].normalizedTime = (float)returnProcess[i].turnaroundTime / returnProcess[i].burstTime;//normalizedTime 계산
        }
        for (int i = 0; i < returnProcess.Count(); i++)
            process[i] = returnProcess[i];

        for (int i = 0; i < process.Count(); i++)
        {//사용했던 변수 초기화
            process[i].dyArrivalTime = 0;
            process[i].dyburstTime = 0;
            process[i].rrTime = 0;
        }
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                scheduledProcess[i].Add(-1);
            }
        }
        endTime = scheduledProcess[0].Count();
    }
}





