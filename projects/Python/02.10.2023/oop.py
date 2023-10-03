class Person():
    def __init__(self, name, secondName, qual=1):
        self.name = name
        self.secondName = secondName
        self.qual = qual
    def __str__(self):
        return  f"{self.name} {self.secondName} {self.qual}"
    def __del__(self):
        print(f"До свидания, мистер {self.name} {self.secondName}")
        del self

if __name__ == "__main__":
    d = []
    d.append(Person(name="A", secondName="a", qual=3))
    d.append(Person(name="B", secondName="b"))
    d.append(Person(name="C", secondName="c", qual=0))

    for item in d:
        if item.qual == min(x.qual for x in d):
            d.remove(item)
            del item
            break

    print("\n \n \n^^^^^^^^^^^^")
    #с input() ошибка, т.к. программа ожидает ввод
