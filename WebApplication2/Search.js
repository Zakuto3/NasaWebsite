init();

//Just run init
function init() {
    let inputbox = document.getElementById("search-text");
    let resultList = document.getElementById("searchResults");
    inputbox.addEventListener("keyup", function () { search(inputbox, resultList); });
    inputbox.addEventListener("focus", function () { search(inputbox, resultList); });
    inputbox.addEventListener("blur", function () { hideList(resultList); });
}

//Sends the ajax call if more than 3 letters and inputbox is focused
function search(input, resultList) {
    if (input.value.length > 3 && input === document.activeElement) {
        ajaxcall(input.value, resultList);
    }
    else {
        hideList(resultList);
    }
}

//Sends searchstring to server and fills searchlist with results
function ajaxcall(search, resultList) {
    let request = new XMLHttpRequest();
    let url = "AjaxReq.aspx?search=" + search;
    request.onreadystatechange = function () {
        if (request.readyState == "4" && request.status == 200) {
            let news = JSON.parse(request.responseText); //parse the JSON into an array
            if (news.length > 0) {
                clearResults(resultList); //clear list before adding new ones
                news.forEach(function (value) {
                    let listItem = document.createElement("a");
                    listItem.innerHTML = "<li style='margin-top: 4%;'>" + value + "</li>";
                    resultList.appendChild(listItem);
                })
                resultList.style.display = "block";
            }
            else {
                hideList(resultList);
            }
        }
    }
    request.open("GET", url, true);
    request.send();
}

//Clear the current searchlist 
function clearResults(resultList) {
    let currentResults = Array.from(resultList.children); //Convert object to array for "forEach"
    currentResults.forEach(function (child) {
        child.remove();
    })
}

//hide list, code reuse purpose
function hideList(list) {
    list.style.display = "none";
}