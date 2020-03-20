using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Models
{
    public class Work
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int CityId { get; set; }

        public string Name { get; set; }

        private string description;
        public string Description
        {
            get
            {
                if (description != null)
                    return description;
                else
                {
                    return "Нужно написать описание для этой работы. " +
                        "По типу сделаем то то то за столько то времени. " +
                        "Будем отрубать свет";
                }
            }
            set
            {
                description = value;
            }
        }

        public int Price { get; set; }

        public bool IsDescription
        {
            get
            {
                if (Description != null)
                    return true;
                else
                    return false;
            }
        }

        private string piece;
        public string Piece
        {
            get
            {
                if (piece != null)
                {
                    switch (piece)
                    {
                        case "":
                            return null;
                        case "м.п":
                            return "/м.п";
                        default:
                            return "/шт.";
                    }
                }
                else
                    return "/шт.";
            }
            set
            {
                piece = value;
            }
        }
    }
}
