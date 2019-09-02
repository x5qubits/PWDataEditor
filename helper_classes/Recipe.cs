using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PWDataEditorPaied.helper_classes
{
    public class Recipe
    {
        public int ID = 0;
        public string Name = "";
        public int recipe_level = 0;
        public int id_skill = 0;
        public int skill_level = 0;
        public int bind_type = 0;
        public int targets_1_id_to_make_rowId = 0;
        public int targets_2_id_to_make_rowId = 0;
        public int targets_3_id_to_make_rowId = 0;
        public int targets_4_id_to_make_rowId = 0;
        public int targets_1_id_to_make = 0;
        public int targets_2_id_to_make = 0;
        public int targets_3_id_to_make = 0;
        public int targets_4_id_to_make = 0;
        public string targets_1_probability = "";
        public string targets_2_probability = "";
        public string targets_3_probability = "";
        public string targets_4_probability = "";
        public int targets_1_probability_rowId = 0;
        public int targets_2_probability_rowId = 0;
        public int targets_3_probability_rowId = 0;
        public int targets_4_probability_rowId = 0;
        public int num_to_make = 0;
        public int num_to_make_rowId = 0;
        public float duration = 0;
        public int duration_rowId = 0;
        public int exp = 0;
        public int skillpoint = 0;
        public Dictionary<int, string> materials = new Dictionary<int, string>();
        public Dictionary<int, string> materials_count = new Dictionary<int, string>();
        public int id_upgrade_equip = 0;
        public int id_upgrade_equip_rowId = 0;
        public string upgrade_rate = "";
        public int proc_type = 0;
        public int character_combo_id = 0;
        public string upgrade_engrave_rate = "";
        public string upgrade_addon_rate = "";
        public int recipe_level_rowId = 0;
        public int id_skill_rowId = 0;
        public int skill_level_rowId = 0;
        public int bind_type_rowId = 0;
        public int exp_rowId = 0;
        public int skillpoint_rowId = 0;
        public int upgrade_rate_rowId = 0;
        public int proc_type_rowId = 0;
        public int character_combo_id_rowId = 0;
        public int upgrade_engrave_rate_rowId = 0;
        public int upgrade_addon_rate_rowId = 0;
        public int list = 0;
        public int index = 0;
        public int Name_rowId = 0;
        public int ID_rowId = 0;
        public int price;
        public int fail_probability_rowId;
        public float fail_probability;
        public int id_major_type;
        public int id_major_type_rowId;
        public int id_sub_type;
        public int id_sub_type_rowId;
    }
}
