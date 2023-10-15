class Order:
    """

    """

    def __init__(self, order_id: int, manager_id: int, client_id: int, order_date: str, amount: float):
        """ """
        self.order_id = order_id
        self.manager_id = manager_id
        self.client_id = client_id
        self.order_date = order_date
        self.amount = amount

    def __str__(self):
        return f"{self.order_id}. {self.manager_id} {self.client_id} {self.order_date} {self.amount:.2f}"


if __name__ == '__main__':
    orders = []
    with open("order.txt", "r", encoding="ansi") as orders_f:
        for line in orders_f:
            order_id, manager_id, cliend_id, order_date, amount = line.split(";")
            order_id = int(order_id)
            manager_id = int(manager_id)
            cliend_id = int(cliend_id)
            amount = float(amount)
            order = Order(order_id, manager_id, cliend_id, order_date, amount)
            orders.append(order)
    with open("orders_sorted.txt", "w", encoding="utf-8") as orders_sorted_f:
        orders_sorted_f.write("order_id, manager_id, cliend_id, order_date, amount\n")
        for order in sorted(orders, key=lambda x: x.amount, reverse=True):
            orders_sorted_f.write(str(order) + "\n")
print("orders done")
