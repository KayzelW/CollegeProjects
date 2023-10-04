import openpyxl
from PyQt6 import QtCore, QtWidgets
from PyQt6.QtWidgets import QApplication, QMainWindow, QWidget
from openpyxl.utils import range_boundaries
from ExcelWindow import ExcelDataPlot
import sys


class DialogWindow:
    def __init__(self, app: QApplication):
        self.__appREF = app
        self.__excelWindow = None

        self.__window = QMainWindow()
        self.__window.setWindowTitle("Окно графика")
        self.__window.setGeometry(100, 100, 450, 130)
        # setGeometry(self, ax: int, ay: int, aw: int, ah: int)

        self.centralWidget = QWidget(self.__window)
        self.__window.setCentralWidget(self.centralWidget)

        self.widget = QtWidgets.QWidget(parent=self.centralWidget)
        self.widget.setGeometry(QtCore.QRect(40, 0, 300, 100))
        self.widget.setObjectName("widget")

        self.verticalLayout = QtWidgets.QVBoxLayout(self.widget)
        self.verticalLayout.setContentsMargins(0, 0, 0, 0)

        self.label = QtWidgets.QLabel(parent=self.widget)
        self.label.setText("Введите диапазон ячеек в формате A1:B5")
        self.label.setFixedWidth(400)
        self.lineEdit = QtWidgets.QLineEdit(parent=self.widget)
        self.execute = QtWidgets.QPushButton(parent=self.widget)
        self.execute.setText('Отобразить график')
        self.execute.clicked.connect(self.executeButtonAction)

        self.verticalLayout.addWidget(self.label)
        self.verticalLayout.addWidget(self.lineEdit)
        self.verticalLayout.addWidget(self.execute)

    def executeButtonAction(self):
        wb = openpyxl.load_workbook('excelFile.xlsx')
        sheet = wb.active
        args = range_boundaries(self.lineEdit.text())
        data = [row for row in sheet.iter_rows(
            min_col=args[0], min_row=args[1], max_col=args[2], max_row=args[3], values_only=True)]
        wb.close()
        if self.__excelWindow == None:
            self.__excelWindow = ExcelDataPlot(data, self.__appREF)
            self.execute.setText('Перерисовать')
        else:
            self.__excelWindow.hide()
            self.__excelWindow.reExecute(data)
        self.__excelWindow.show()

    def show(self):
        self.__window.show()


if __name__ == "__main__":
    app = QApplication(sys.argv)
    dialogWindow = DialogWindow(app)
    dialogWindow.show()
    sys.exit(app.exec())
