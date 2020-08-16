$(document).ready(function () {
    $('.custom-file-input').on("change", function () {
            var fileName = $(this).val().split("\\").pop();
            if (fileName.length > 20) {
                fileName = fileName.substring(0, 20) + "...";
            }
            $(this).next('.custom-file-label').html(fileName);
        }
    );
});

var loadFile = function (event) {
    var output = document.getElementById('output');
    output.src = URL.createObjectURL(event.target.files[0]);
};


        function PrintDiv() {
            var divToPrint = document.getElementById('print');
            var popupWin = window.open('', '_blank');
            popupWin.document.open();
            popupWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</html>');
            popupWin.document.close();
        }

function printDiv(divName) {
    var printContents = document.getElementById(divName).innerHTML;
    var originalContents = document.body.innerHTML;

    document.body.innerHTML = printContents;

    window.print();

    document.body.innerHTML = originalContents;
}
   
