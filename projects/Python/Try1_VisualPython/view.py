from PyQt6 import QtCore
from PyQt6.QtWidgets import QVBoxLayout, QWidget
import numpy as np
from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg as Fg
from matplotlib.figure import Figure


class DiagramWindow(QWidget):
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
        # QtCore.QMetaObject.connectSlotsByName(self)
        self.translations()

    def translations(self):
        _translate = QtCore.QCoreApplication.translate
        self.setWindowTitle(_translate("DiagramWindow", "График"))

    def plot_function(self, x1=-100, x2=100, a=1, b=0, c=0):
        x = np.linspace(x1, x2, 160)
        y = a * x * x + b * x + c
        self.ax.clear()
        self.ax.plot(x, y, label='Parabola')
        self.ax.set_xlabel('X')
        self.ax.set_ylabel("Y")
        self.ax.legend()
        self.canvas.draw()
