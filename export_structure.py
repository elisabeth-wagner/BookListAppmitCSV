import os

OUTPUT_FILE = "project_dump.txt"

def build_tree(path, prefix=""):
    lines = []
    items = sorted(os.listdir(path))
    for i, item in enumerate(items):
        full_path = os.path.join(path, item)
        connector = "└── " if i == len(items) - 1 else "├── "
        lines.append(prefix + connector + item)
        if os.path.isdir(full_path):
            extension = "    " if i == len(items) - 1 else "│   "
            lines.extend(build_tree(full_path, prefix + extension))
    return lines

def collect_files(path):
    file_list = []
    for root, dirs, files in os.walk(path):
        for f in files:
            full_path = os.path.join(root, f)
            file_list.append(full_path)
    return file_list

def main():
    base_path = os.getcwd()
    with open(OUTPUT_FILE, "w", encoding="utf-8") as out:
        out.write("=== STRUCTURE ===\n\n")
        tree = build_tree(base_path)
        out.write("\n".join(tree))
        out.write("\n\n\n=== FILE CONTENTS ===\n\n")

        for file_path in collect_files(base_path):
            out.write(f"\n--- {file_path} ---\n")
            try:
                with open(file_path, "r", encoding="utf-8") as f:
                    out.write(f.read())
            except:
                out.write("[UNREADABLE FILE]\n")

    print("Готово. Файл создан:", OUTPUT_FILE)

if __name__ == "__main__":
    main()
