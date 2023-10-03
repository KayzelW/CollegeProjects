class VectorCoord:
    def __set_name__(self, owner, name):
        print('\n-----------------------------',
              self,
              owner,
              name,
              '(__set_name__)------------', sep='\n')
        self.name = '_' + name

    def __get__(self, instance, owner):
        print('\n-----------------------------',
              self,
              instance,
              owner,
              self.name,
              '(__get__)------------', sep='\n')
        return instance.__dict__[self.name]

    def __set__(self, instance, value):
        print('\n-----------------------------',
              self,
              instance,
              value,
              '(__set__)------------', sep='\n')
        instance.__dict__[self.name] = value


class Vector:
    x = VectorCoord()
    y = VectorCoord()
    z = VectorCoord()

    def __init__(self, x=0, y=0, z=0):
        print('^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^')
        self.x = x
        self.y = y
        self.z = z


if __name__ == "__main__":
    v = Vector(2, 2, 2)
    print('^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^', '\n')
    print(v.x, v.y, v.z)
    print(v._x, v._y, v._z)
    print(v.__dict__)
    print(id(v.x))
    print(id(v._x))
