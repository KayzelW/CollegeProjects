import matplotlib.pyplot as plt
from PyQt6.QtWidgets import QMainWindow, QVBoxLayout, QWidget
from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg as FigureCanvas

class ExcelDataPlot:
    def __init__(self, data):
        self.__window = QMainWindow()
        self.__window.setWindowTitle("Окно графика")
        self.__window.setGeometry(100, 100, 800, 600)

        self.central_widget = QWidget(self.__window)
        self.__window.setCentralWidget(self.central_widget)

        layout = QVBoxLayout(self.central_widget)

        self.figure, self.ax = plt.subplots()
        self.canvas = FigureCanvas(self.figure)
        layout.addWidget(self.canvas)

        xData, yData = zip(*data)
        self.ax.plot(xData, yData)
        self.ax.set_xlabel('X')
        self.ax.set_ylabel('Y')

    def show(self):
        self.__window.show()