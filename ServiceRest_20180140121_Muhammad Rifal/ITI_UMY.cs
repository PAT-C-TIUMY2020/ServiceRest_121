﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceRest_20180140121_Muhammad_Rifal
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITI_UMY
    {
        [OperationContract]
        [WebGet(UriTemplate = "Mahasiswa", ResponseFormat = WebMessageFormat.Json)] //untuk membuat slash, selalu realtive
        List<Mahasiswa> GetAllMahasiswa(); //mendapatkan kumpulan mahasiswa/seluruh data mahasiswa

        [OperationContract]                          //nama method
        [WebGet(UriTemplate = "Mahasiswa/nim={nim}", ResponseFormat = WebMessageFormat.Json)] //untuk get
        Mahasiswa GetMahasiswaByNIM(string nim); //mengambil data berdasarkan nim

        //void CreateMahasiswa(mahasiswa mhs); tidak ada pengembalian/respond balik
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Mahasiswa", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string CreateMahasiswa(Mahasiswa mhs);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "ServiceRest_20180140093_Musafak.ContractType".
    [DataContract]
    public class Mahasiswa
    {
        private string _nama, _nim, _prodi, _angkatan; //adalah konvensi atau kesepakatan variable lokal
        [DataMember(Order = 1)] //mengirim data untuk mengurutkan
        public string nama
        {
            get { return _nama; }
            set { _nama = value; }
        }
        [DataMember(Order = 2)]
        public string nim
        {
            get { return _nim; }
            set { _nim = value; }
        }
        [DataMember(Order = 3)]
        public string prodi
        {
            get { return _prodi; }
            set { _prodi = value; }
        }
        [DataMember(Order = 4)]
        public string angkatan
        {
            get { return _angkatan; }
            set { _angkatan = value; }
        }
    }
}