from PyQt6 import QtCore, QtWidgets
from PyQt6.QtWidgets import QApplication, QMainWindow, QWidget
from openpyxl.utils import range_boundaries
from ExcelWindow import ExcelDataPlot
import sys


class DialogWindow:
    def __init__(self, app: QApplication):
        self.appREF = app

        self.__window = QMainWindow()
        self.__window.setWindowTitle("Окно графика")
        self.__window.setGeometry(100, 100, 800, 600)

        self.centralWidget = QWidget(self.__window)
        self.__window.setCentralWidget(self.centralWidget)

        self.widget = QtWidgets.QWidget(parent=self.centralWidget)
        self.widget.setGeometry(QtCore.QRect(40, 60, 159, 159))
        self.widget.setObjectName("widget")

        self.verticalLayout = QtWidgets.QVBoxLayout(self.widget)
        self.verticalLayout.setContentsMargins(0, 0, 0, 0)

        self.label = QtWidgets.QLabel(parent=self.widget)
        self.label.setText("Введите диапазон ячеек в формате A1:B5")
        self.lineEdit = QtWidgets.QLineEdit(parent=self.widget)
        self.execute = QtWidgets.QPushButton(parent=self.widget)
        self.execute.clicked.connect(self.executeButtonAction)

        self.verticalLayout.addWidget(self.label)
        self.verticalLayout.addWidget(self.lineEdit)
        self.verticalLayout.addWidget(self.execute)

    def executeButtonAction(self):
        excelWindow = ExcelDataPlot(range_boundaries(self.lineEdit.text()))
        excelWindow.show()
        self.appREF.exec()

    def show(self):
        self.__window.show()


if __name__ == "__main__":
    app = QApplication(sys.argv)
    dialogWindow = DialogWindow(app)
    dialogWindow.show()
    sys.exit(app.exec())
