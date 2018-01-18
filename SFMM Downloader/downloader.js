var div=document.createElement("div"); 
var downloadIMG = chrome.extension.getURL("download.png");
document.body.appendChild(div);
var theDiv = document.getElementsByTagName("footer")[0];
var content = document.createTextNode("SFMM Downloader V1.5");
theDiv.appendChild(content);
div.innerHTML = div.innerHTML += ' <a style="position: fixed; bottom: 0; left: 3px; z-index: 1;" href="SFMM:'+window.location.href+'"><img src=https://i.imgur.com/BxO6Pjx.png height="124" width="124"></a>';