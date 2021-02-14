$(function () {
    let searchbut = document.getElementById('searchbut');
    let fileUpload = $('#ContentPlaceHolder1_upPoster');
    let wrapper = document.getElementsByClassName('wrapper')[0];
    let remove = $('#fileRemove');

    let img = $('#poster');
    if (img) {
        showText(img);
    }

    img = $('#ContentPlaceHolder1_poster');
    if (img) {
        showText(img);
    }

    if (searchbut) {
        searchbut.addEventListener('click', search);
    }

    if (wrapper) {
        wrapper.addEventListener('click', clickUpload);
    }

    if (fileUpload) {
        fileUpload.on('change', function () {
            preview();
        });
    }

    if (remove) {
        remove.on('click', function () {
            let mask = $('#fileMask');
            let cardText = $('.card-text');
            let remove = $('#fileRemove');
            mask.addClass('d-none');
            remove.addClass('d-none');
            cardText.removeClass('d-none');
            fileUpload.val('');
            let img = $('#poster');
            if (img) {
                img.attr('src', '/Content/img/placeholder.jpg');
            }
            img = $('#ContentPlaceHolder1_poster');
            if (img) {
                img.attr('src', '/Content/img/placeholder.jpg');
            }
        })
    }
});

function clickUpload() {
    let fileUpload = $('#ContentPlaceHolder1_upPoster');
    fileUpload.click();
}

function showText(img) {
    if (img.attr('src') == '/Content/img/placeholder.jpg') {
        let cardText = $('.filepreview > .wrapper > .card-text');
        if ($(cardText).hasClass('d-none')) {
            cardText.removeClass('d-none');
        }
    }
    else if (img.attr('id') == 'ContentPlaceHolder1_poster' && img.attr('src') != '/Content/img/placeholder.jpg') {
        let input = $('#ContentPlaceHolder1_upPoster');
        let mask = $('#fileMask');
        let cardText = $('.card-text');
        let remove = $('#fileRemove');
        cardText.addClass('d-none');
        mask.removeClass('d-none');
        remove.removeClass('d-none');
    }
}

function preview() {
    let input = document.getElementById('ContentPlaceHolder1_upPoster');
    let cardText = $('.filepreview > .wrapper > .card-text');
    let file = input.files;
    let reader = new FileReader();
    reader.onload = function (e) {
        let img = $('#poster');
        if (img) {
            img.attr('src', e.target.result);
        }
        img = $('#ContentPlaceHolder1_poster');
        if (img) {
            img.attr('src', e.target.result);
        }
    }

    if (file && file[0]) {
        reader.readAsDataURL(file[0]);
    }

    if (!$(cardText).hasClass('d-none')) {
        $(cardText).addClass('d-none');
    }

    input = $('#ContentPlaceHolder1_upPoster')

    let mask = $('#fileMask');
    let maskText = $('#maskText');
    cardText = $('.card-text');
    let remove = $('#fileRemove');
    if (input.val() != "") {
        let fileName = input.val().split('\\');
        maskText.html(fileName[fileName.length - 1]);
        cardText.addClass('d-none');
        mask.removeClass('d-none');
        remove.removeClass('d-none');
    }
    else {
        mask.addClass('d-none');
        remove.addClass('d-none');
        cardText.removeClass('d-none');
    }
    
}

function search() {
    let input = $('#search').val();
    let filter = input.toUpperCase();
    let cards = $('.servicecards');
    let name = $('.name');

    for (let i = 0, n = cards.length; i < n; i++) {
        let focus = $(cards[i]);
        let compare = $(name[i]).data('name');

        if (compare.toUpperCase().includes(filter)) {
            if ($(focus).hasClass('d-none')) {
                $(focus).removeClass('d-none');
                $(focus).addClass('animated faster fadeIn').one("animationend", function () {
                    let _this = $(this);

                    _this.removeClass('animated faster fadeIn');
                    _this.addClass('d-flex');
                });
            }
        }
        else {
            if (!$(focus).hasClass('d-none')) {
                $(focus).addClass('animated faster fadeOut').one("animationend", function () {
                    let _this = $(this);

                    _this.removeClass('animated faster fadeOut');
                    _this.removeClass('d-flex');
                    _this.addClass('d-none');
                })
            }
        }
    }
}

$('select.category-select').on('change', function (e) {
    let cards = $('.servicecards');
    let category = $(this).find('option:selected').text().replace(/\s/g, '');

    for (let i = 0, n = cards.length; i < n; i++) {
        let focus = $(cards[i]);

        if (($(focus).hasClass(category) || category === "ShowAll")) {
            if ($(focus).hasClass('d-none')) {
                $(focus).removeClass('d-none');
                $(focus).addClass('animated faster fadeIn').one("animationend", function () {
                    let _this = $(this);

                    _this.removeClass('animated faster fadeIn');
                    _this.addClass('d-flex');
                });
            }
        }
        else {
            if (!$(focus).hasClass('d-none')) {
                $(focus).addClass('animated faster fadeOut').one("animationend", function () {
                    let _this = $(this);

                    _this.removeClass('animated faster fadeOut');
                    _this.addClass('d-none');
                    _this.removeClass('d-flex');
                })
            }
        }
    }
});


$('select.sort-select').on('change', function (e) {
    let cards = $('.servicecards');
    let sort = $(this).find('option:selected').text();
    if (sort == "Newest first") {
        cards.sort(function (a, b) { return $(b).data("id") - $(a).data("id") });
        $("#servcon").html(cards);
    }
    else if (sort == "Oldest first") {
        cards.sort(function (a, b) { return $(a).data("id") - $(b).data("id") });
        $("#servcon").html(cards);
    }
    else if (sort == "Most Viewed") {
        cards.sort(function (a, b) { return $(b).data("views") - $(a).data("views") });
        $("#servcon").html(cards);
    }
    else if (sort == "Most Popular") {
        cards.sort(function (a, b) { return $(b).data("favs") - $(a).data("favs") });
        $("#servcon").html(cards);
    }
});

// Material Design example
$(document).ready(function () {
    let table = $('#requests-table', 'section.requests');
    let trs = $('tbody tr', '#requests-table');

    $('input[name="search"]', 'section.requests').on('keyup', function () {
        let val = $(this).val().toLowerCase();
        let shown = trs.length;

        trs.each(function () {
            let _this = $(this);

            if (val) {
                let tds = _this.children('td[headers]:not([headers="action"], [id="empty-search"])');
                let show = false;

                for (let i = 0, n = tds.length; i < n && !show; i++) {
                    td = $(tds[i]);

                    if (td.text().toLowerCase().indexOf(val) > -1) {
                        show = true;
                    }
                }

                if (show && _this.attr('style')) {
                    _this.removeAttr('style');

                    _this.addClass('flipInX').on("animationEnd", function () {
                        _this.removeClass('flipInX');
                    });
                }
                else if (!show) {
                    if (!_this.attr('style')) {
                        _this.addClass('flipOutX').on("animationEnd", function () {
                            _this.removeClass('flipOutX');
                            _this.prop('style', 'display: none !important;');
                        });
                    }

                    shown--;
                }
            }
            else {
                if (_this.attr('style')) {
                    _this.removeAttr('style');
                    _this.addClass('flipInX').on("animationEnd", function () {
                        $(this).removeClass('flipInX');
                    });
                }
            }
        });

        $('#empty-search', '#requests-table').remove();

        if (shown < 1) {
            $('tbody', '#requests-table').prepend(`
                <tr id="empty-search">
                    <td class="rounded-bottom" colspan=100>
                        Couldn\'t find anything for <span class="font-weight-bolder">${val}</span>
                    </td>
                </tr>
            `);
        }
    });
});