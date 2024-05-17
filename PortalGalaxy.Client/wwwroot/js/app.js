window.getTableHtml = function() {
    var table = document.getElementById('tablaConDatos');

    return table.outerHTML;
}

function BlazorDownloadFile(filename, content) {
    // con esta funcion vamos a crear un elemento <a> y simularemos el click
    // crear la URL
    const file = new File([content], filename, { type: "application/octet-stream"});
    const exportUrl = URL.createObjectURL(file);

    const a = document.createElement("a");
    document.body.appendChild(a);
    a.href = exportUrl;
    a.download = filename;
    a.target = "_self";
    a.click();

    // No necesito conservar la URL
    URL.revokeObjectURL(exportUrl);
}