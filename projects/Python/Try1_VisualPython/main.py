from PyQt6 import QtCore, QtWidgets
from PyQt6.QtWidgets import QMainWindow, QMessageBox
from view import DiagramWindow
class MainWindow(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setObjectName("MainWindow")
        self.resize(496, 403)

        self.centralwidget = QtWidgets.QWidget(self)
        self.centralwidget.setObjectName("centralwidget")

        self.widget = QtWidgets.QWidget(parent=self.centralwidget)
        self.widget.setGeometry(QtCore.QRect(160, 80, 159, 188))
        self.widget.setObjectName("widget")

        self.verticalLayout_3 = QtWidgets.QVBoxLayout(self.widget)
        self.verticalLayout_3.setContentsMargins(0, 0, 0, 0)
        self.verticalLayout_3.setObjectName("verticalLayout_3")

        self.label_6 = QtWidgets.QLabel(parent=self.widget)
        self.label_6.setObjectName("label_6")

        self.verticalLayout_3.addWidget(self.label_6, 0, QtCore.Qt.AlignmentFlag.AlignHCenter)

        self.verticalLayout_2 = QtWidgets.QVBoxLayout()
        self.verticalLayout_2.setObjectName("verticalLayout_2")
        self.verticalLayout = QtWidgets.QVBoxLayout()
        self.verticalLayout.setObjectName("verticalLayout")
        self.horizontalLayout = QtWidgets.QHBoxLayout()
        self.horizontalLayout.setObjectName("horizontalLayout")

        self.label = QtWidgets.QLabel(parent=self.widget)
        self.label.setObjectName("x1Label")

        self.Edit_X1 = QtWidgets.QLineEdit(parent=self.widget)
        self.Edit_X1.setObjectName("Edit_X1")

        self.horizontalLayout.addWidget(self.label)
        self.horizontalLayout.addWidget(self.Edit_X1)
        self.verticalLayout.addLayout(self.horizontalLayout)
        self.horizontalLayout_2 = QtWidgets.QHBoxLayout()
        self.horizontalLayout_2.setObjectName("horizontalLayout_2")
        self.label_2 = QtWidgets.QLabel(parent=self.widget)
        self.label_2.setObjectName("x2Label")
        self.horizontalLayout_2.addWidget(self.label_2)
        self.Edit_X2 = QtWidgets.QLineEdit(parent=self.widget)
        self.Edit_X2.setObjectName("Edit_X2")
        self.horizontalLayout_2.addWidget(self.Edit_X2)
        self.verticalLayout.addLayout(self.horizontalLayout_2)
        self.horizontalLayout_3 = QtWidgets.QHBoxLayout()
        self.horizontalLayout_3.setObjectName("horizontalLayout_3")
        self.label_3 = QtWidgets.QLabel(parent=self.widget)
        self.label_3.setObjectName("aLabel")
        self.horizontalLayout_3.addWidget(self.label_3)
        self.Edit_A = QtWidgets.QLineEdit(parent=self.widget)
        self.Edit_A.setObjectName("Edit_A")
        self.horizontalLayout_3.addWidget(self.Edit_A)
        self.verticalLayout.addLayout(self.horizontalLayout_3)
        self.horizontalLayout_4 = QtWidgets.QHBoxLayout()
        self.horizontalLayout_4.setObjectName("horizontalLayout_4")
        self.label_4 = QtWidgets.QLabel(parent=self.widget)
        self.label_4.setObjectName("bLabel")
        self.horizontalLayout_4.addWidget(self.label_4)
        self.Edit_B = QtWidgets.QLineEdit(parent=self.widget)
        self.Edit_B.setObjectName("Edit_B")
        self.horizontalLayout_4.addWidget(self.Edit_B)
        self.verticalLayout.addLayout(self.horizontalLayout_4)
        self.horizontalLayout_5 = QtWidgets.QHBoxLayout()
        self.horizontalLayout_5.setObjectName("horizontalLayout_5")
        self.label_5 = QtWidgets.QLabel(parent=self.widget)
        self.label_5.setObjectName("cLabel")
        self.horizontalLayout_5.addWidget(self.label_5)
        self.Edit_C = QtWidgets.QLineEdit(parent=self.widget)
        self.Edit_C.setObjectName("Edit_C")
        self.horizontalLayout_5.addWidget(self.Edit_C)
        self.verticalLayout.addLayout(self.horizontalLayout_5)
        self.verticalLayout_2.addLayout(self.verticalLayout)

        self.pushButton = QtWidgets.QPushButton(parent=self.widget)
        self.pushButton.setObjectName("pushButton")
        self.pushButton.clicked.connect(self.executeButtonAction)


        self.verticalLayout_2.addWidget(self.pushButton)
        self.verticalLayout_3.addLayout(self.verticalLayout_2)
        self.setCentralWidget(self.centralwidget)

        #QtCore.QMetaObject.connectSlotsByName(self)
        _translate = QtCore.QCoreApplication.translate
        self.setWindowTitle(_translate("MainWindow", "Посторить график"))
        self.label_6.setText(_translate("MainWindow", "y = ax^2+bx+c"))
        self.label.setText(_translate("MainWindow", "X1"))
        self.label_2.setText(_translate("MainWindow", "X2"))
        self.label_3.setText(_translate("MainWindow", "A"))
        self.label_4.setText(_translate("MainWindow", "B"))
        self.label_5.setText(_translate("MainWindow", "C"))
        self.pushButton.setText(_translate("MainWindow", "Построить"))

    def executeButtonAction(self):
        try:
            x1 = float(self.Edit_X1.text())
            x2 = float(self.Edit_X2.text())
            a = float(self.Edit_A.text())
            b = float(self.Edit_B.text())
            c = float(self.Edit_C.text())
            self.d = DiagramWindow()
            self.d.plot_function(x1, x2, a, b, c)
            self.d.show()
        except:
            msg = QMessageBox()
            msg.setIcon(QMessageBox.Icon.Critical)
            msg.setText("Ошибка")
            msg.setInformativeText('Ты ввел не то!!!')
            msg.setWindowTitle("Чудо природы:")
            msg.exec()

if __name__ == "__main__":
    import sys
    app = QtWidgets.QApplication(sys.argv)
    Main = MainWindow()
    Main.show()
    sys.exit(app.exec())
