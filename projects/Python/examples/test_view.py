from PyQt6 import QtCore, QtGui, QtWidgets
from PyQt6.QtWidgets import QVBoxLayout, QWidget, QApplication, QMainWindow
import numpy as np
from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg as Fg
from matplotlib.figure import Figure

class Dialog(QWidget):
    def __init__(self):
        super().__init__()
        self.setObjectName("DiagramWindow")
        self.resize(400, 300)

        self.layout = QVBoxLayout()
        self.setLayout(self.layout)
        fig = Figure(figsize=(5, 4), dpi=100)
        self.canvas = Fg(fig)

        self.layout.addWidget(self.canvas)

        self.ax = fig.add_subplot(111)

        QtCore.QMetaObject.connectSlotsByName(self)

        _translate = QtCore.QCoreApplication.translate
        self.setWindowTitle(_translate("DiagramWindow", "График"))


    def plot_function(self):
        x = np.linspace(-2 * np.pi, 2 * np.pi, 160)
        y = np.sin(x)
        self.ax.clear()
        self.ax.plot(x, y, label='sin(x)')
        self.ax.set_xlabel('X')
        self.ax.set_ylabel("Y")
        self.ax.legend()
        self.canvas.draw()

