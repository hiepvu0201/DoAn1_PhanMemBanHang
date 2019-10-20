function toggleSidebar() {
    var x = document.getElementById('side-bar').classList.toggle('active');
    var list = document.getElementsByClassName("content")[0].classList.toggle('active');
    var list1 = document.getElementsByClassName("footer")[0].classList.toggle('active');
}

function showSidebarBase() {
    var list = document.getElementsByClassName("dropdown-base")[0].classList.toggle('active');
}

function showSidebarTables() {
    var list = document.getElementsByClassName("dropdown-tables")[0].classList.toggle('active');
}