import matplotlib.pyplot as plt
from PyQt6.QtWidgets import QApplication, QMainWindow, QVBoxLayout, QWidget, QDialog
from PyQt6.QtCore import Qt
from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg as FigureCanvas


class ExcelDataPlot:
    def __init__(self, data, app: QApplication):
        self.__appREF = app
        self.__window = QMainWindow()
        self.__window.setWindowFlag(Qt.WindowType.WindowStaysOnTopHint)
        self.__window.setWindowTitle("Окно графика")
        self.__window.setGeometry(100, 100, 800, 600)

        self.central_widget = QWidget(self.__window)
        self.__window.setCentralWidget(self.central_widget)

        self.figure, self.ax = plt.subplots()
        self.canvas = FigureCanvas(self.figure)

        layout = QVBoxLayout(self.central_widget)
        layout.addWidget(self.canvas)

        self.__xData, self.__yData = zip(*data)
        self.ax.plot(self.__xData, self.__yData)
        self.ax.set_xlabel('X')
        self.ax.set_ylabel('Y')
        self.canvas.draw()

    def show(self):
        self.__window.show()
        self.__appREF.exec()
    def hide(self):
        self.__window.hide()

    def reExecute(self, data):
        self.__xData, self.__yData = zip(*data)
        self.ax.plot(self.__xData, self.__yData)
        self.ax.set_xlabel('X')
        self.ax.set_ylabel('Y')
        self.canvas.draw()
