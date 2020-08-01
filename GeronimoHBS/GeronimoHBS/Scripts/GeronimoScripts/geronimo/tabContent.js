function showGymClasses(evt, gymClassName) {
    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("timetableColumnTitle");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" activeDaySelected", "");
    }
    document.getElementById(gymClassName).style.display = "block";
    evt.currentTarget.className += " activeDaySelected";
}