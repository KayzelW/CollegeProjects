from PyQt6 import QtCore, QtWidgets
from PyQt6.QtWidgets import QMainWindow, QMessageBox
from view import *


class EnterDataWindow:
    def __init__(self):
        self.dialogWindow = DiagramWindow()
        self.__window = QtWidgets.QMainWindow()
        self.__window.setObjectName("EnterDataWindow")
        self.__window.resize(280, 254)

        self.centralwidget = QtWidgets.QWidget(parent=self.__window)
        self.centralwidget.setObjectName("centralwidget")

        self.formula = QtWidgets.QLabel(parent=self.centralwidget)
        self.formula.setGeometry(QtCore.QRect(81, 30, 85, 18))
        self.formula.setObjectName("formula")

        self.widget = QtWidgets.QWidget(parent=self.centralwidget)
        self.widget.setGeometry(QtCore.QRect(40, 60, 159, 159))
        self.widget.setObjectName("widget")
        self.gridLayout = QtWidgets.QGridLayout(self.widget)
        self.gridLayout.setContentsMargins(5, 4, 3, 2)
        self.gridLayout.setObjectName("gridLayout")

        self.aLine = QtWidgets.QLineEdit(parent=self.widget)
        self.aLine.setObjectName("aLine")
        self.x1Line = QtWidgets.QLineEdit(parent=self.widget)
        self.x1Line.setObjectName("x1Line")
        self.x2Line = QtWidgets.QLineEdit(parent=self.widget)
        self.x2Line.setObjectName("x2Line")
        self.bLine = QtWidgets.QLineEdit(parent=self.widget)
        self.bLine.setObjectName("bLine")
        self.cLine = QtWidgets.QLineEdit(parent=self.widget)
        self.cLine.setObjectName("cLine")

        self.executeButton = QtWidgets.QPushButton(parent=self.widget)
        self.executeButton.setObjectName("executeButton")
        self.executeButton.clicked.connect(self.executeButtonAction)

        self.x1Label = QtWidgets.QLabel(parent=self.widget)
        self.x1Label.setObjectName("x1Label")
        self.x2Label = QtWidgets.QLabel(parent=self.widget)
        self.x2Label.setObjectName("x2Label")
        self.aLabel = QtWidgets.QLabel(parent=self.widget)
        self.aLabel.setObjectName("aLabel")
        self.bLabel = QtWidgets.QLabel(parent=self.widget)
        self.bLabel.setObjectName("bLabel")
        self.cLabel = QtWidgets.QLabel(parent=self.widget)
        self.cLabel.setObjectName("cLabel")

        self.retranslateUi()
        self.widgetAdds()
        self.__window.setCentralWidget(self.centralwidget)
        # self.statusbar = QtWidgets.QStatusBar(parent=self.__window)
        # self.statusbar.setObjectName("statusbar")
        # self.__window.setStatusBar(self.statusbar)

        QtCore.QMetaObject.connectSlotsByName(self.__window)

    def show(self):
        self.__window.show()

    def hide(self):
        self.__window.hide()

    def retranslateUi(self):
        _translate = QtCore.QCoreApplication.translate
        self.__window.setWindowTitle(_translate("EnterDataWindow", "Окно ввода данных"))
        self.formula.setText(_translate("EnterDataWindow", "y = ax^2+bx+c"))
        self.x1Label.setText(_translate("EnterDataWindow", "X1"))
        self.x2Label.setText(_translate("EnterDataWindow", "X2"))
        self.aLabel.setText(_translate("EnterDataWindow", "A"))
        self.bLabel.setText(_translate("EnterDataWindow", "B"))
        self.cLabel.setText(_translate("EnterDataWindow", "C"))
        self.executeButton.setText(_translate("EnterDataWindow", "Построить график"))

    def widgetAdds(self):
        self.gridLayout.addWidget(self.aLine, 2, 1, 1, 1)
        self.gridLayout.addWidget(self.x1Line, 0, 1, 1, 1)
        self.gridLayout.addWidget(self.x2Line, 1, 1, 1, 1)
        self.gridLayout.addWidget(self.x2Label, 1, 0, 1, 1)
        self.gridLayout.addWidget(self.x1Label, 0, 0, 1, 1)
        self.gridLayout.addWidget(self.bLabel, 3, 0, 1, 1)
        self.gridLayout.addWidget(self.bLine, 3, 1, 1, 1)
        self.gridLayout.addWidget(self.cLine, 4, 1, 1, 1)
        self.gridLayout.addWidget(self.aLabel, 2, 0, 1, 1)
        self.gridLayout.addWidget(self.cLabel, 4, 0, 1, 1)
        self.gridLayout.addWidget(self.executeButton, 5, 0, 1, 2)

    def executeButtonAction(self):
        try:
            x1 = float(self.x1Line.text())
            x2 = float(self.x2Line.text())
            a = float(self.aLine.text())
            b = float(self.bLine.text())
            c = float(self.cLine.text())
            self.dialogWindow.hide()
            self.dialogWindow.plot_function(x1, x2, a, b, c)
            self.dialogWindow.show()
        except ValueError:
            msg = QMessageBox()
            msg.setIcon(QMessageBox.Icon.Critical)
            msg.setText("Ошибка")
            msg.setInformativeText('Ты ввел не то!!!')
            msg.setWindowTitle("Чудо природы:")
            msg.exec()


if __name__ == "__main__":
    import sys

    app = QtWidgets.QApplication(sys.argv)
    window = EnterDataWindow()
    window.show()
    sys.exit(app.exec())
