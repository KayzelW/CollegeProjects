class Client:
    """

    """
    def __init__(self, client_id: int, name: str, city: str, rating: int, manager_id: int):
        """ """
        self.client_id = client_id
        self.name = name
        self.city = city
        self.rating = rating
        self.manager_id = manager_id
    def __str__(self):
        return f"{self.client_id}. {self.name} {self.city} {self.rating} {self.manager_id}"
