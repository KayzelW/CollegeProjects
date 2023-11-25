#include <stdio.h>
#include <stdlib.h>

typedef struct {
    int seconds;
} Time;

//инициализатор 1
Time createTime(int hours, int minutes, int seconds) {
    Time newTime;
    newTime.seconds = hours * 3600 + minutes * 60 + seconds;
    return newTime;
}

//инициализатор 2
Time fromDateTime(int hours, int minutes, int seconds) {
    return createTime(hours, minutes, seconds);
}

//инициализатор 3
Time fromTotalSeconds(int totalSeconds) {
    return createTime(0, 0, totalSeconds);
}

//инициализатор 4
Time fromTimeString(char* timeString) {
    int hours, minutes, seconds;
    if (sscanf(timeString, "%d:%d:%d", &hours, &minutes, &seconds) == 3) {
        return createTime(hours, minutes, seconds);
    }
    else {
        printf("Invalid time string format\n");
        exit(EXIT_FAILURE);
    }
}

//Разница секунд
int differenceInSeconds(Time time1, Time time2) {
    return abs(time1.seconds - time2.seconds);
}

//Добавление секунд
Time addSeconds(Time time, int secondsToAdd) {
    time.seconds += secondsToAdd;
    return time;
}

//метод вычитания секунд
Time subtractSeconds(Time time, int secondsToSubtract) {
    time.seconds -= secondsToSubtract;
    if (time.seconds < 0) {
        time.seconds = 0;
    }
    return time;
}

//метод проверки равенства
int equals(Time time1, Time time2) {
    return time1.seconds == time2.seconds;
}

//конвертация в секунды
int toSeconds(Time time) {
    return time.seconds;
}
//конвертация в минуты
int toMinutes(Time time) {
    return (int)(time.seconds / 60.0 + 0.5);
}

//Вывод времени
void printTime(Time time) {
    printf("%02d:%02d:%02d\n", time.seconds / 3600, (time.seconds % 3600) / 60, time.seconds % 60);
}



int main() {
    Time time1 = createTime(1, 30, 0);
    Time time2 = createTime(0, 45, 0);

    Time result1 = addSeconds(time1, toSeconds(time2));
    Time result2 = subtractSeconds(time1, toSeconds(time2));

    printTime(result1);
    printTime(result2);

    Time time3 = fromDateTime(12, 34, 56);
    Time time4 = fromTotalSeconds(5000);
    Time time5 = fromTimeString("02:15:30");

    printTime(time3);
    printTime(time4);
    printTime(time5);

    return 0;
}
