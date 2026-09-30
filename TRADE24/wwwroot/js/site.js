// ============================================================================
// Trade24 - site.js
// ============================================================================

(function () {
    'use strict';

    var STORAGE_KEY = 'trade24.sidebarCollapsed';

    var sidebar = document.getElementById('sidebarMenu');
    var btnToggle = document.getElementById('btnToggleSidebar');

    if (!sidebar || !btnToggle) return;

    var icon = btnToggle.querySelector('i');

    function isCollapsed() {
        return localStorage.getItem(STORAGE_KEY) === '1';
    }

    function setIcon(collapsed) {
        if (!icon) return;
        icon.classList.toggle('bi-arrow-bar-left', !collapsed);
        icon.classList.toggle('bi-arrow-bar-right', collapsed);
    }

    function applyState(collapsed) {
        sidebar.classList.toggle('sidebar-collapsed', collapsed);
        setIcon(collapsed);
    }

    // Aplica el estado guardado al cargar la página (sin animación,
    // usando la clase *-init definida en site.css para evitar el flash)
    var collapsedOnLoad = isCollapsed();
    if (collapsedOnLoad) {
        sidebar.classList.add('sidebar-collapsed-init');
    }
    applyState(collapsedOnLoad);

    // Quita la clase "sin transición" después del primer frame para que
    // los siguientes toggles sí se animen
    requestAnimationFrame(function () {
        sidebar.classList.remove('sidebar-collapsed-init');
    });

    // Toggle al hacer clic
    btnToggle.addEventListener('click', function () {
        var collapsed = !sidebar.classList.contains('sidebar-collapsed');
        applyState(collapsed);
        localStorage.setItem(STORAGE_KEY, collapsed ? '1' : '0');
    });
})();