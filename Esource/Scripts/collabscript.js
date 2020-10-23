$(function () {
    let searchbut = document.getElementById('searchbut');

    if (searchbut) {
        searchbut.addEventListener('click', search);
    }
});

function search() {
    let input = $('#search').val();
    let filter = input.toUpperCase();
    let cards = $('.postcards');
    let name = $('.posttitle');

    for (let i = 0, n = cards.length; i < n; i++) {
        let focus = $(cards[i]);
        let compare = $(name[i]).data('title');

        if (compare.toUpperCase().includes(filter)) {
            if ($(focus).hasClass('d-none')) {
                $(focus).removeClass('d-none');
                $(focus).addClass('animated faster fadeIn').one("animationend", function () {
                    let _this = $(this);

                    _this.removeClass('animated faster fadeIn');
                });
            }
        }
        else {
            if (!$(focus).hasClass('d-none')) {
                $(focus).addClass('animated faster fadeOut').one("animationend", function () {
                    let _this = $(this);

                    _this.removeClass('animated faster fadeOut');
                    _this.addClass('d-none');
                })
            }
        }
    }
}

$('select.sort-select').on('change', function (e) {
    let cards = $('.postcards');
    let sort = $(this).find('option:selected').text();
    if (sort == "Newest first") {
        cards.sort(function (a, b) { return $(b).data("id") - $(a).data("id") });
        $("#postcon").html(cards);
    }
    else if (sort == "Oldest first") {
        cards.sort(function (a, b) { return $(a).data("id") - $(b).data("id") });
        $("#postcon").html(cards);
    }
    else if (sort == "Most Viewed") {
        cards.sort(function (a, b) { return $(b).data("views") - $(a).data("views") });
        $("#postcon").html(cards);
    }
    else if (sort == "Most Liked") {
        cards.sort(function (a, b) { return $(b).data("likes") - $(a).data("likes") });
        $("#postcon").html(cards);
    }
});