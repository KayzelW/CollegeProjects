class Manager:
    """

    """
    def __init__(self, manager_id: int, name: str, city: str, comm: float):
        """ """
        self.manager_id = manager_id
        self.name = name
        self.city = city
        self.comm = comm
    def __str__(self):
        return f"{self.manager_id}. {self.name} {self.city} {self.comm}"
