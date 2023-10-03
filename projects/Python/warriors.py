import random


class Warrior(object):
    def __init__(self, health=100, dmg=10, name="UnknownWarrior"):
        """
        Базовая инициализация Warrior
            возможнные значения:
            health - целое число
            dmg - целое число
            name - строка
        """
        self.__name = name
        self.__health = health
        self.__attack = dmg

    @property
    def attack(self):
        """Возвращает кол-во урона, которое наносит Warrior при атаке"""
        return self.__attack

    @property
    def health(self):
        """Возвращает здоровье Warrior"""
        return self.__health

    @health.setter
    def health(self, new):
        """
        Изменяет здоровье self. Не даёт ему опуститься ниже 0
        Не учитывает возможность восстановления здоровья
        """
        if (new < 0):
            self.__health = 0
        else:
            self.__health = new

    @property
    def name(self):
        """Возвращает имя Warrior"""
        return self.__name

    def deal_dmg(self, defender):
        """
        От имени вызывающего наносит урон тому, кто передан в качестве аргумента

        Ключевые слова:
        self - передаётся автоматически. Ссылка на исполнителя(Warrior)
        defender - цель атаки исполнителя. Ссылка на другого Warrior
        """
        if not isinstance(defender, Warrior):
            raise TypeError('Нужно передавать объект класса Warrior')
        if self is defender:
            raise ValueError('Нельзя атаковать самого себя!')
        defender.health -= self.attack
        print(f"{self.name} нанёс {self.attack} урона {defender.name}")


if __name__ == "__main__":
    warrior1 = Warrior(health=200, dmg=8, name="Alexandr")
    warrior2 = Warrior(health=80, dmg=20, name="Cesar")
    while (warrior1.health > 0) and (warrior2.health > 0):
        # start-changes
        """После написания программы узнал о существовании метода choice и немного переписал"""
        attacker = random.choice([warrior1, warrior2])
        defender = warrior1 if attacker == warrior2 else warrior2
        attacker.deal_dmg(defender)
    if warrior1.health <= 0:
        print(f"{warrior2.name} одержал победу!")
    else:
        print(f"{warrior1.name} одержал победу!")
        # end-changes
        """
        #первая версия
        match state:
            case 0:
                warrior1.deal_dmg(warrior2)
                if (warrior2.health == 0):
                    print(f"{warrior1.name} победил!")
                print(warrior2.health)
            case 1:
                warrior2.deal_dmg(warrior1)
                if (warrior1.health == 0):
                    print(f"{warrior2.name} победил!")
                print(warrior1.health)
        """
