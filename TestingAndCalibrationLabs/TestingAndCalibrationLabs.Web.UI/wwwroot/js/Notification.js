//variables to manipulate bell Icon Content

var count = 1;
var i = 0;
var mess = " ";
const z = [];
//To hide or display the BellIcon
function DisplayNotification() {

    var x = document.getElementById("Menu");
    var IconRotate = document.getElementById("rotate");
    if (x.style.display == "none") {
        
        IconRotate.classList.toggle("down");
        x.style.display = "block";

    } else {
        IconRotate.classList.toggle("down");
        x.style.display = "none";
        for (var item in z) {
            z[item].style = "background-color:white";
        }
        
    }
};

// To Put the Notification content in the Bell Icon
function ErrorMessage(value,mess) {
  
    if (value ==0) {
        var Notify = document.getElementById("value");
        Notify.innerHTML = "0";
        count = 0;
        document.getElementById("content").innerHTML = " ";
        
    }
    
        count++;
    $('#content').prepend("<div class='notification-list' id='Paragraph'></div>");

    $('#Paragraph').append("<div class='notification-list_detail' id='child'></div>");

    $('#child').append(" <b><p id='Name'  > " + mess + "</p></b>");

    var Notify = document.getElementById("value");

    Notify.innerHTML = count;
    z[i] = document.getElementById('Paragraph');
    z[i].style = "background-color: #E9E9E9;";
    var View = document.getElementById("view");
    View.style.display = "block";  
    z[i].id = "Paragraph" + i;
   
 
};

function SuccessMessage(value, mess) {

    if (value == 0) {
        var Notify = document.getElementById("value");
        Notify.innerHTML = "0";
        count = 0;
        document.getElementById("content").innerHTML = " ";

    }
    count++;
    $('#content').prepend("<div class='notification-list' id='Paragraph'></div>");
    $('#Paragraph').append("<div class='notification-list_detail' id='child'></div>");
      $('#child').append(" <b><p id='Name' style='color:green' > " + mess + "</p></b>");
    var Notify = document.getElementById("value");
    Notify.innerHTML = count;

    z[i] = document.getElementById('Paragraph');
    z[i].style = "background-color: #E9E9E9;";

    
    var View = document.getElementById("view");
    View.style.display = "block";

};

 //To delete the Notification
function Delete() {
    var View = document.getElementById("view");
    View.style.display = "none";
    var Notify = document.getElementById("value");
    Notify.innerHTML = "0";
    count = 0;
    i = 0;
    document.getElementById("content").innerHTML = "<span style='font-weight:bold;'><center>No Notification </center></span>";
};

//To close the BellIcon on Outside Click
window.onclick = function () {
    var x = document.getElementById("Menu");
    if (x.style.display == "block") {
        DisplayNotification();
    }
}

