//variables to manipulate bell Icon Content

var count = 1;
var NotificationNumbers = 0;
var message = " ";
const NotificationItem = [];
//To hide or display the BellIcon
function DisplayNotification() {

    var Icon = document.getElementById("BellIconMenu");
    var IconRotate = document.getElementById("rotate");
    if (Icon.style.display == "none") {

        IconRotate.classList.toggle("down");
        Icon.style.display = "block";
    }
    else {
        IconRotate.classList.toggle("down");
        Icon.style.display = "none";
        for (var item in NotificationItem) {
            NotificationItem[item].style = "background-color:white";
        }
    }
};

// To Put the Notification content in the Bell Icon
function ErrorMessage(value, message) {

    if (value == 0) {
        var Notify = document.getElementById("value");
        Notify.innerHTML = "0";
        count = 0;
        document.getElementById("dropdownContentNotifications").innerHTML = " ";

    }

    count++;
    $('#dropdownContentNotifications').prepend("<div class='notification-list' id='Paragraph'></div>");
    $('#Paragraph').append("<div class='notification-list_detail' id='child'></div>");
    $('#child').append(" <b><p id='Name'  > " + message + "</p></b>");
    var Notify = document.getElementById("value");
    Notify.innerHTML = count;
    NotificationItem[NotificationNumbers] = document.getElementById('Paragraph');
    NotificationItem[NotificationNumbers].style = "background-color: #E9E9E9;";
    var View = document.getElementById("view");
    View.style.display = "block";
    NotificationItem[NotificationNumbers].id = "Paragraph" + NotificationNumbers;
};

function SuccessMessage(value, message) {

    if (value == 0) {
        var Notify = document.getElementById("value");
        Notify.innerHTML = "0";
        count = 0;
        document.getElementById("dropdownContentNotifications").innerHTML = " ";

    }
    count++;
    $('#dropdownContentNotifications').prepend("<div class='notification-list' id='Paragraph'></div>");
    $('#Paragraph').append("<div class='notification-list_detail' id='child'></div>");
    $('#child').append(" <b><p id='Name' style='color:green' > " + message + "</p></b>");
    var Notify = document.getElementById("value");
    Notify.innerHTML = count;
    NotificationItem[NotificationNumbers] = document.getElementById('Paragraph');
    NotificationItem[NotificationNumbers].style = "background-color: #E9E9E9;";
    var View = document.getElementById("view");
    View.style.display = "block";
    NotificationItem[NotificationNumbers].id = "Paragraph" + NotificationNumbers;
};

//To delete the Notification
function Delete() {
    var View = document.getElementById("view");
    View.style.display = "none";
    var Notify = document.getElementById("value");
    Notify.innerHTML = "0";
    count = 0;
    NotificationNumbers = 0;
    document.getElementById("dropdownContentNotifications").innerHTML = "<span style='font-weight:bold;'><center>No Notification </center></span>";
};

//To close the BellIcon on Outside Click
window.onclick = function () {
    var Icon = document.getElementById("BellIconMenu");
    if (Icon) {

        if (Icon.style.display == "block" && Icon !== null) {
            DisplayNotification();
        }

    }

}

