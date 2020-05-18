const uri = 'api/shops';
let shops = [];

function getShops() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayShops(data))
        .catch(error => console.error('Unable to get shops.', error));
}

function addShop() {
    const addCityIdTextbox = document.getElementById('add-cityId');
    const addNameTextbox = document.getElementById('add-name');
    const addAddressTextbox = document.getElementById('add-address');
    const addPhoneTextbox = document.getElementById('add-phone');
    const addAreaTextbox = document.getElementById('add-area');

    const shop = {
        cityId: parseInt(addCityIdTextbox.value, 10),
        name: addNameTextbox.value.trim(),
        address: addAddressTextbox.value.trim(),
        phone: parseInt(addPhoneTextbox.value, 10),
        area: parseInt(addAreaTextbox.value, 10),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(shop)
    })
        .then(response => response.json())
        .then(() => {
            getShops();
            addCityIdTextbox.value = '';
            addNameTextbox.value = '';
            addAddressTextbox.value = '';
            addPhoneTextbox.value = '';
            addAreaTextbox.value = '';
        })
        .catch(error => console.error('Unable to add shop.', error));
}

function deleteShop(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getShops())
        .catch(error => console.error('Unable to delete shop.', error));
}

function displayEditForm(id) {
    const shop = shops.find(shop => shop.id === id);

    document.getElementById('edit-id').value = shop.id;
    document.getElementById('edit-cityId').value = shop.cityId;
    document.getElementById('edit-name').value = shop.name;
    document.getElementById('edit-address').value = shop.address;
    document.getElementById('edit-phone').value = shop.phone;
    document.getElementById('edit-area').value = shop.area;
    document.getElementById('editForm').style.display = 'block';
}

function updateShop() {
    const shopId = document.getElementById('edit-id').value;
    const shopPhone = document.getElementById('edit-phone').value;
    const shopArea = document.getElementById('edit-area').value;

    const shop = {
        id: parseInt(shopId, 10),
        cityId: parseInt(document.getElementById('edit-cityId').value, 10),
        name: document.getElementById('edit-name').value.trim(),
        address: document.getElementById('edit-address').value.trim(),
        phone: document.getElementById('edit-phone').value.trim(),
        area: parseInt(shopArea, 10)
    };

    fetch(`${uri}/${shopId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(shop)
    })
        .then(() => getShops())
        .catch(error => console.error('Unable to update shop.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayShops(data) {
    const tBody = document.getElementById('shops');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(shop => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${shop.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteShop(${shop.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNodeCityId = document.createTextNode(shop.cityId);
        td1.appendChild(textNodeCityId);

        let td2 = tr.insertCell(1);
        let textNode = document.createTextNode(shop.name);
        td2.appendChild(textNode);

        let td3 = tr.insertCell(2);
        let textNodeAddress = document.createTextNode(shop.address);
        td3.appendChild(textNodeAddress);

        let td4 = tr.insertCell(3);
        let textNodePhone = document.createTextNode(shop.phone);
        td4.appendChild(textNodePhone);

        let td5 = tr.insertCell(4);
        let textNodeArea = document.createTextNode(shop.area);
        td5.appendChild(textNodeArea);

        let td6 = tr.insertCell(5);
        td6.appendChild(editButton);

        let td7 = tr.insertCell(6);
        td7.appendChild(deleteButton);
    });

    shops = data;
}
