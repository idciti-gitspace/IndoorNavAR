using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class QrHandler : MonoBehaviour
{
    [SerializeField]
    private TextAsset qrModelData;
    [SerializeField]
    private GameObject qrObjectPrefab;
    [SerializeField]
    private Transform qrObjectsParentTransform;

    private List<QrList> currentQrItems = new List<QrList>();

    private List<GameObject> qrlist = new List<GameObject>();

    private void Start()
    {
        GenerateQrItems();
    }

    private void GenerateQrItems()
    {
        IEnumerable<Qr> qrs = GenerateQrDataFromSource();
        foreach (Qr qr in qrs)
        {
            currentQrItems.Add(CreateQrList(qr));
        }
    }

    private IEnumerable<Qr> GenerateQrDataFromSource()
    {
        return JsonUtility.FromJson<QrWrapper>(qrModelData.text).QrList;
    }

    private QrList CreateQrList(Qr qr)
    {
        GameObject qrObject = Instantiate(qrObjectPrefab, qrObjectsParentTransform, false);
        qrObject.SetActive(true);
        qrObject.name = qr.Name;
        qrObject.transform.localPosition = qr.Position;
        qrObject.transform.localRotation = Quaternion.Euler(qr.Rotation);

        QrList qrData =  qrObject.GetComponent<QrList>();
        qrData.Name = qr.Name;
        return qrData;
    }

    public QrList GetCurrentQrByQrText(string qrText)
    {
        return currentQrItems.Find(x =>
        x.Name.ToLower().Equals(qrText.ToLower()));
    }
}
