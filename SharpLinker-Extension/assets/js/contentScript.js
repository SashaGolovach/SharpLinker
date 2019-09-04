console.log('works');

let images = document.getElementsByTagName('img');
for (let i = 0; i < 10; i++) {
    chrome.runtime.sendMessage({ msg: 'image', index: i }, function ({ data, index }) {
        images[index].src = data.link;
    });
}