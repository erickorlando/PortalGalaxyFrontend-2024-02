export function generateAndDownloadPdf(htmlElement, filename) {
    const doc = new jspdf.jsPDF({
        orientation: 'p',
        unit:'pt',
        format: 'a4'
    });

    return new Promise((resolve, reject) => {
        doc.html(htmlElement, {
            callback: doc => {
                doc.save(filename);
                resolve();
            }
        });
    });
}