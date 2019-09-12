function createSortMenu() {
    var header = document.getElementsByTagName('header')[0];
    var div = document.createElement('div');
    div.className = 'wrapper';
    header.after(div);
    var main = document.createElement('main');
    div.prepend(main);

    var sortMenu = document.createElement('div');
    sortMenu.className = 'sortMenu';
    var span = document.createElement('span');
    span.innerHTML = 'Сортировать по ';
    sortMenu.append(span);
    var select = document.createElement('select');
    select.setAttribute('onclick', 'sort()');
    var sortPrice = document.createElement('option');
    sortPrice.innerHTML = 'цене';
    select.append(sortPrice);
    var sortName = document.createElement('option');
    sortName.innerHTML = 'названию';
    select.append(sortName);
    var sortRating = document.createElement('option');
    sortRating.innerHTML = 'количеству отзывов';
    select.append(sortRating);
    sortMenu.append(select);

    main.append(sortMenu);
}

function printSmth(arg) {
    alert(arg);
}