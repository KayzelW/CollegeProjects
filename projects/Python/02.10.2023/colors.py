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

        self.textLabel = QtWidgets.QLabel(parent=self.widget)
        self.textLabel.setObjectName("textLabel")
        self.viewColorLabel = QtWidgets.QLabel(parent=self.widget)
        self.viewColorLabel.setObjectName("viewColorLabel")

        self.redButton = QtWidgets.QPushButton(parent=self.widget)
        self.redButton.setStyle('QPushButton {background-color: red; color: white;}')
        self.orangeButton = QtWidgets.QPushButton(parent=self.widget)
        self.yellowButton = QtWidgets.QPushButton(parent=self.widget)
        self.greenButton = QtWidgets.QPushButton(parent=self.widget)
        self.blueButton = QtWidgets.QPushButton(parent=self.widget)
        self.oceanButton = QtWidgets.QPushButton(parent=self.widget)
        self.perpleButton = QtWidgets.QPushButton(parent=self.widget)

        self.translations()
        self.setupWidgets()

        self.setCentralWidget(self.centralwidget)

    def translations(self):
        """Элемент локализации выведенный в отдельную функцию для читабельности кода"""
        _translate = QtCore.QCoreApplication.translate
        self.setWindowTitle(_translate("MainWindow", "Калькулятор - альфа версия"))

    def setupWidgets(self):
        """Монтаж объектов QtWidgets в verticalLayout выведенный в отдельную функцию для читабельности кода"""
        self.verticalLayout.addWidget(self.textLabel)
        self.verticalLayout.addWidget(self.viewColorLabel, 0, QtCore.Qt.AlignmentFlag.AlignHCenter)
        self.verticalLayout.addWidget(self.redButton)
        self.verticalLayout.addWidget(self.orangeButton)
        self.verticalLayout.addWidget(self.yellowButton)
        self.verticalLayout.addWidget(self.greenButton)
        self.verticalLayout.addWidget(self.blueButton)
        self.verticalLayout.addWidget(self.oceanButton)
        self.verticalLayout.addWidget(self.perpleButton)

    def viewColor(self, color):
        self.viewColorLabel.setText(color)


if __name__ == "__main__":
    import sys

    app = QtWidgets.QApplication(sys.argv)
    main = MainWindow()
    main.show()
    sys.exit(app.exec())
