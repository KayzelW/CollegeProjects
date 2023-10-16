from client import Client
from manager import Manager
from order import Order


class Trade:
    """

    """

    def __init__(self, trade_id: int):
        """ """
        self.trade_id = trade_id
        self.managers = []
        self.clients = []
        self.orders = []

    def add_manager(self, manager: Manager):
        """ """
        self.managers.append(manager)

    def add_client(self, client: Client):
        """ """
        pass  # ToDo

    def add_order(self, order: Order):
        """ """
        pass  # ToDo

    def __str__(self):
        # ToDo
        return "?"

    def read_managers(self, managers_fname):
        with open(managers_fname, "r") as managers_f:
            for line in managers_f:
                manager_id, name, city, comm = line.split(";")
                manager_id = int(manager_id)
                comm = float(comm)
                manager = Manager(manager_id, name, city, comm)
                self.managers.append(manager)

    def Kovrov_managers(self):
        """ """
        res = []
        for manager in self.managers:
            if manager.city.upper() == 'КОВРОВ':
                res.append(manager)
        return res


if __name__ == '__main__':
    trade = Trade(1)
    trade.read_managers("manager.txt")
    # ToDo
    # trade.read_clients("client.txt")
    # trade.read_orders("order.txt")

    print('Ковровские продавцы')
    print('manager_id name city comm')
    for manager in trade.Kovrov_managers():
        print(manager)
    print()
