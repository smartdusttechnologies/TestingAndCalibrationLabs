
var count = 1;
var i = 0;
var mess = " ";

//To hide or display the BellIcon
function fun1() {

    var x = document.getElementById("ritesh");
    if (x.style.display == "none") {
      
        x.style.display = "block";

    } else {
        x.style.display = "none";
    }
};

// To Put the Notification in the Bell Icon
function fun2(value,mess) {
  
    if (value ==0) {
        var Notify = document.getElementById("value");
        Notify.innerHTML = "0";
        count = 0;
        document.getElementById("content").innerHTML = " ";
        
    }
  
        count++;
        $('#content').prepend("<div class='notification-list' id='Paragraph'></div>");
        $('#Paragraph').append("<div class='notification-list_detail' id='child'></div>");
    $('#child').append(" <b><p id='Name'>. " + mess +"</p></b>");
        var Notify = document.getElementById("value");
        Notify.innerHTML = count;
 
};

 //To delete the Notification
function Del() {
    var Notify = document.getElementById("value");
    Notify.innerHTML = "0";
    count = 0;
    i = 0;
    document.getElementById("content").innerHTML = "<b>No Notification</b>";
};

//To close the BellIcon on Outside Click
window.onclick = function () {
    var x = document.getElementById("ritesh");
    x.style.display = "none";
}

