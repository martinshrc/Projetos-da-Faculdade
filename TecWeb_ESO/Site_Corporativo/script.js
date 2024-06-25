document.getElementById('toggleMenu').addEventListener('click', function () {
    var sidebar = document.getElementById('sidebar');
    var main = document.querySelector('main');
    if (sidebar.style.width === '200px') {
        sidebar.style.width = '0';
        main.classList.add('sidebar-collapsed');
    } else {
        sidebar.style.width = '200px';
        main.classList.remove('sidebar-collapsed');
    }
});
