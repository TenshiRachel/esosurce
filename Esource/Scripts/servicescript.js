$(function () {
    let searchbut = document.getElementById('searchbut');

    if (searchbut) {
        searchbut.addEventListener('click', search);
    }
});

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