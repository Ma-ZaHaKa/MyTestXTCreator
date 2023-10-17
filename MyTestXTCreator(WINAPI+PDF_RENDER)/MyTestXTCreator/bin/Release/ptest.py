import os
import sys
import subprocess
import getopt

from PyQt5 import QtCore, QtWidgets, QtWebEngineWidgets



def html_to_pdf(html, pdf):
    #setAttribute(Qt::WA_DeleteOnClose)
    app = QtWidgets.QApplication(sys.argv)

    page = QtWebEngineWidgets.QWebEnginePage()

    def handle_print_finished(filename, status):
        print("True", filename, status)
        QtWidgets.QApplication.quit()
        #system('taskkill /F /IM QtWebEngineProcess.exe')
        subprocess.call(["taskkill","/F","/IM","QtWebEngineProcess.exe"])

    def handle_load_finished(status):
        if status:
            page.printToPdf(pdf)
        else:
            print("False")
            QtWidgets.QApplication.quit()
            subprocess.call(["taskkill","/F","/IM","QtWebEngineProcess.exe"])

    page.pdfPrintingFinished.connect(handle_print_finished)
    page.loadFinished.connect(handle_load_finished)
    page.load(QtCore.QUrl.fromLocalFile(html))
    app.exec_()



def main(argv):
   inputfile = ''
   outputfile = ''
   opts, args = getopt.getopt(argv,"hi:o:",["ifile=","ofile="])
   for opt, arg in opts:
      if opt == '-h':
         #print ('test.py -i <inputfile> -o <outputfile>')
         sys.exit()
      elif opt in ("-i", "--ifile"):
         inputfile = arg
      elif opt in ("-o", "--ofile"):
         outputfile = arg
   #print ('Input file is ', inputfile)
   #print ('Output file is ', outputfile)
   CURRENT_DIR = os.path.dirname(os.path.realpath(__file__))
   filename = os.path.join(CURRENT_DIR, "in.html")
   #html_to_pdf(filename, "test.pdf")
   #print(filename)
   if inputfile != '' and outputfile != '':
     #print ('Input file is ', inputfile)
     #print ('Output file is ', outputfile)
     html_to_pdf(inputfile, outputfile)
   else:
     print("False")


if __name__ == "__main__":

    #CURRENT_DIR = os.path.dirname(os.path.realpath(__file__))
    #filename = os.path.join(CURRENT_DIR, "index.html")
    #print(filename)
    #print("by DIKTOR");
    #html_to_pdf(filename, "out.pdf")
    main(sys.argv[1:])