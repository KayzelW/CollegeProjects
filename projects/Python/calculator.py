from PyQt6 import QtCore, QtWidgets
from PyQt6.QtWidgets import QMainWindow, QMessageBox


class MainWindow(QMainWindow):
    def __init__(self):
        """Базовая инициализация окна калькулятора"""
        super().__init__()
        self.setObjectName("MainWindow")
        self.resize(356, 340)
        self.centralwidget = QtWidgets.QWidget(parent=self)
        self.centralwidget.setObjectName("centralwidget")

        self.widget = QtWidgets.QWidget(parent=self.centralwidget)
        self.widget.setGeometry(QtCore.QRect(110, 70, 135, 183))
        self.widget.setObjectName("widget")
        self.verticalLayout = QtWidgets.QVBoxLayout(self.widget)
        self.verticalLayout.setContentsMargins(0, 0, 0, 0)
        self.verticalLayout.setObjectName("verticalLayout")

        self.lineEdit = QtWidgets.QLineEdit(parent=self.widget)
        self.lineEdit.setObjectName("lineEdit")
        self.lineEdit_2 = QtWidgets.QLineEdit(parent=self.widget)
        self.lineEdit_2.setObjectName("lineEdit_2")

        self.plusButton = QtWidgets.QPushButton(parent=self.widget)
        self.plusButton.setObjectName("plusButton")
        self.minusButton = QtWidgets.QPushButton(parent=self.widget)
        self.minusButton.setObjectName("minusButton")
        self.multiplyButton = QtWidgets.QPushButton(parent=self.widget)
        self.multiplyButton.setObjectName("multiplyButton")
        self.divideButton = QtWidgets.QPushButton(parent=self.widget)
        self.divideButton.setObjectName("divideButton")
        self.label = QtWidgets.QLabel(parent=self.widget)
        self.label.setObjectName("x1Label")

        self.plusButton.clicked.connect(
            lambda: self.label.setText(str(int(self.lineEdit.text()) + int(self.lineEdit_2.text())))
        )

        self.minusButton.clicked.connect(
            lambda: self.label.setText(str(int(self.lineEdit.text()) - int(self.lineEdit_2.text())))
        )

        self.multiplyButton.clicked.connect(
            lambda: self.label.setText(str(int(self.lineEdit.text()) * int(self.lineEdit_2.text())))
        )

        self.divideButton.clicked.connect(
            lambda: self.label.setText(str(int(self.lineEdit.text()) / int(self.lineEdit_2.text()))
                                       if int(self.lineEdit_2.text()) not in (0, None) else None)
        )

        self.translations()
        self.setupWidgets()

        self.setCentralWidget(self.centralwidget)

    def translations(self):
        """Элемент локализации выведенный в отдельную функцию для читабельности кода"""
        _translate = QtCore.QCoreApplication.translate
        self.setWindowTitle(_translate("MainWindow", "Калькулятор - альфа версия"))
        self.plusButton.setText(_translate("MainWindow", "+"))
        self.minusButton.setText(_translate("MainWindow", "-"))
        self.multiplyButton.setText(_translate("MainWindow", "*"))
        self.divideButton.setText(_translate("MainWindow", "/"))
        self.label.setText(_translate("MainWindow", ""))

    def setupWidgets(self):
        """Монтаж объектов QtWidgets в verticalLayout выведенный в отдельную функцию для читабельности кода"""
        self.verticalLayout.addWidget(self.lineEdit)
        self.verticalLayout.addWidget(self.lineEdit_2)
        self.verticalLayout.addWidget(self.plusButton)
        self.verticalLayout.addWidget(self.minusButton)
        self.verticalLayout.addWidget(self.multiplyButton)
        self.verticalLayout.addWidget(self.divideButton)
        self.verticalLayout.addWidget(self.label, 0, QtCore.Qt.AlignmentFlag.AlignHCenter)


if __name__ == "__main__":
    import sys

    app = QtWidgets.QApplication(sys.argv)
    main = MainWindow()
    main.show()
    sys.exit(app.exec())
