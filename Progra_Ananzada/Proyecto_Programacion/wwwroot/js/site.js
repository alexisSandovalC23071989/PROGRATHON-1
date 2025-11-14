// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    // Variables
    var $body = $('body');
    var $live = $('#live-region');

    // --- ALERTAS DE ACCESO ---
    function accessibleAlert(message) {
        // Actualiza 
        $live.text(message);
        // también crea un aviso visual
        showTemporaryToast(message);
    }

    function showTemporaryToast(msg) {
        var $toast = $('<div class="sr-only" role="status" aria-live="polite"></div>').text(msg);
        $('body').append($toast);
        setTimeout(function () { $toast.remove(); }, 3000);
    }

    // --- HIGH CONTRAST TOGGLE --- //
    $('#btn-contrast').on('click', function () {
        var $btn = $(this);
        var enabled = $body.hasClass('high-contrast');
        if (enabled) {
            $body.removeClass('high-contrast');
            $btn.attr('aria-pressed', 'false');
            accessibleAlert('Modo alto contraste desactivado');
        } else {
            $body.addClass('high-contrast');
            $btn.attr('aria-pressed', 'true');
            accessibleAlert('Modo alto contraste activado');
        }
    });

    // --- FONT SIZE CONTROL --- //
    var scale = 1;
    function applyScale() {
        document.documentElement.style.setProperty('--scale-factor', scale);
        accessibleAlert('Tamaño de fuente ' + Math.round(scale * 100) + '%');
    }
    $('#btn-font-increase').on('click', function () {
        if (scale < 2) { scale += 0.1; applyScale(); }
    });
    $('#btn-font-decrease').on('click', function () {
        if (scale > 0.6) { scale -= 0.1; applyScale(); }
    });


    if (localStorage.getItem('ui-scale')) {
        scale = parseFloat(localStorage.getItem('ui-scale')) || 1;
        applyScale();
    }
    // Continuar con el cambio
    $(window).on('beforeunload', function () { localStorage.setItem('ui-scale', scale); });

    // --- KEYBOARD: Enter / Space en elementos como accion de botones ---
    $(document).on('keydown', function (e) {
        // Global shortcut: Alt+H para ir al contenido del main
        if (e.altKey && e.key.toLowerCase() === 'h') {
            e.preventDefault();
            $('#main-content').focus();
            accessibleAlert('Foco en contenido principal');
        }
    });

    // Hacer que las teclas que no sean ENTER / SPACE no sean funcionales
    $(document).on('keypress', '[role="button"], .action-btn, .list-item', function (e) {
        var code = e.which || e.keyCode;
        if (code === 13 || code === 32) { // Enter or Space
            e.preventDefault();
            $(this).trigger('click');
        }
    });

    // Ejemplos
    $('.action-btn').on('click', function (e) {
        e.preventDefault();
        var label = $(this).attr('aria-label') || $(this).text();
        accessibleAlert(label + ' activado');
    });

    // Permitir lista de elementos con un enter
    $('.list-item').on('click', function () {
        $(this).toggleClass('selected');
        accessibleAlert($(this).text() + ($(this).hasClass('selected') ? ' seleccionado' : ' deseleccionado'));
    });

    // --- CONTRAST CHECKER: comprueba relación entre color de texto y fondo ---
    function hexToRgb(hex) {
        hex = hex.replace('#', '');
        if (hex.length === 3) hex = hex.split('').map(function (h) { return h + h; }).join('');
        var bigint = parseInt(hex, 16);
        return [(bigint >> 16) & 255, (bigint >> 8) & 255, bigint & 255];
    }
    function luminance(r, g, b) {
        var srgb = [r, g, b].map(function (c) {
            c /= 255;
            return (c <= 0.03928) ? (c / 12.92) : Math.pow((c + 0.055) / 1.055, 2.4);
        });
        return 0.2126 * srgb[0] + 0.7152 * srgb[1] + 0.0722 * srgb[2];
    }
    function contrastRatio(fgHex, bgHex) {
        var f = luminance.apply(null, hexToRgb(fgHex));
        var b = luminance.apply(null, hexToRgb(bgHex));
        var L1 = Math.max(f, b), L2 = Math.min(f, b);
        return (L1 + 0.05) / (L2 + 0.05);
    }

    // Comprueba elementos significativos y notifica
    function checkContrastOnPage() {
        // ejemplo: compara body text con background variable
        try {
            var fg = rgbToHex(window.getComputedStyle(document.body).color);
            var bg = rgbToHex(window.getComputedStyle(document.body).backgroundColor);
            var ratio = contrastRatio(fg, bg);
            if (ratio < 4.5) {
                accessibleAlert('Advertencia: el contraste entre texto y fondo es ' + ratio.toFixed(2) + ':1 (menor a 4.5:1). Active el modo alto contraste si lo necesita.');
            } else {
                // opcional: indicar que está aceptable
                console.info('Contraste Aceptable: ' + ratio.toFixed(2) + ':1');
            }
        } catch (err) {
            console.warn('Imposible comprobar contraste ', err);
        }
    }

    // Helpers: rgb(a) to hex
    function componentToHex(c) {
        var hex = c.toString(16);
        return hex.length == 1 ? "0" + hex : hex;
    }
    function rgbToHex(rgbStr) {
        // formato: rgb(r, g, b) o rgba(...)
        var parts = rgbStr.replace(/\s+/g, '').match(/rgba?\((\d+),(\d+),(\d+)/i);
        if (!parts) return '#000000';
        return '#' + componentToHex(parseInt(parts[1])) + componentToHex(parseInt(parts[2])) + componentToHex(parseInt(parts[3]));
    }

    // Ejecutar al inicio
    checkContrastOnPage();

    // Revisar cuando cambia alto contraste
    $('#btn-contrast').on('click', function () {
        setTimeout(checkContrastOnPage, 50);
    });

    // ---- Focus management: salto rápido al contenido (Skip link) si exists
    // (si añades un "skip to content" enlázalo a #main-content y el foco se gestionará)
});